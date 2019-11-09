using System;
using System.Linq;
using Wilcommerce.Core.Data.EFCore.Events;
using Wilcommerce.Core.Data.EFCore.Test.Fixtures;
using Wilcommerce.Core.Infrastructure;
using Xunit;

namespace Wilcommerce.Core.Data.EFCore.Test.Events
{
    public class EventStoreTest : IClassFixture<EventsFixtures>
    {
        private EventsFixtures _fixtures;

        public EventStoreTest(EventsFixtures fixtures)
        {
            _fixtures = fixtures;
        }

        [Fact]
        public void Ctor_Should_Throw_ArgumentNullException_If_EventsContext_Is_Null()
        {
            EventsContext context = null;

            var ex = Assert.Throws<ArgumentNullException>(() => new EventStore(context));
            Assert.Equal(nameof(context), ex.ParamName);
        }

        [Fact]
        public void Find_NewAdministratorCreatedEvent_Should_Return_Rows_And_Match_Email_And_Name()
        {
            using (var context = _fixtures.BuildContext())
            {
                var eventStore = new EventStore(context);
                _fixtures.PrepareData(context, new NewAdministratorCreatedEvent[]
                {
                    new NewAdministratorCreatedEvent(_fixtures.UserId, "Administrator", "admin@wilcommerce.com")
                });

                var events = eventStore.Find<NewAdministratorCreatedEvent>(DateTime.Now);
                int count = events.Count();

                Assert.True(count > 0);

                bool exists = events.Any(e => e.Email == "admin@wilcommerce.com" && e.Name == "Administrator");
                Assert.True(exists);

                _fixtures.CleanAllData(context);
            }
        }

        [Fact]
        public void FindAll_Should_Return_All_Events_Related_To_Specified_Entity()
        {
            using (var context = _fixtures.BuildContext())
            {
                var eventStore = new EventStore(context);
                _fixtures.PrepareData(context, new DomainEvent[]
                {
                    new NewAdministratorCreatedEvent(_fixtures.UserId, "Administrator", "admin@wilcommerce.com"),
                    new UserEnabledEvent(_fixtures.UserId),
                    new UserDisabledEvent(_fixtures.UserId)
                });

                var entityType = typeof(User);
                var events = eventStore.FindAll(entityType.ToString(), _fixtures.UserId, DateTime.Now);

                int count = events.Count();
                Assert.True(count == 3);

                _fixtures.CleanAllData(context);
            }
        }

        [Fact]
        public void Find_NewAdministratorCreatedEvent_By_EntityType_And_TimeStamp_Should_Return_Rows_And_Match_Email_And_Name()
        {
            using (var context = _fixtures.BuildContext())
            {
                var eventStore = new EventStore(context);
                _fixtures.PrepareData(context, new NewAdministratorCreatedEvent[]
                {
                    new NewAdministratorCreatedEvent(_fixtures.UserId, "Administrator", "admin@wilcommerce.com")
                });

                var entityType = typeof(User);
                var events = eventStore.Find<NewAdministratorCreatedEvent>(entityType.ToString(), DateTime.Now);
                int count = events.Count();

                Assert.True(count > 0);

                bool exists = events.Any(e => e.Email == "admin@wilcommerce.com" && e.Name == "Administrator" && e.AggregateType == entityType);
                Assert.True(exists);

                _fixtures.CleanAllData(context);
            }
        }

        [Fact]
        public void Find_NewAdministratorCreatedEvent_By_EntityType_EntityId_And_TimeStamp_Should_Return_Rows_And_Match_Email_And_Name()
        {
            using (var context = _fixtures.BuildContext())
            {
                var eventStore = new EventStore(context);
                _fixtures.PrepareData(context, new NewAdministratorCreatedEvent[]
                {
                    new NewAdministratorCreatedEvent(_fixtures.UserId, "Administrator", "admin@wilcommerce.com")
                });

                var entityType = typeof(User);
                var events = eventStore.Find<NewAdministratorCreatedEvent>(entityType.ToString(), _fixtures.UserId, DateTime.Now);
                int count = events.Count();

                Assert.True(count > 0);

                bool exists = events.Any(e => e.Email == "admin@wilcommerce.com" && e.Name == "Administrator" && e.AggregateId == _fixtures.UserId && e.AggregateType == entityType);
                Assert.True(exists);

                _fixtures.CleanAllData(context);
            }
        }

        [Fact]
        public void Save_Should_Throw_ArgumentNullException_If_Event_Is_Null()
        {
            using (var context = _fixtures.BuildContext())
            {
                var eventStore = new EventStore(context);

                DomainEvent @event = null;
                var ex = Assert.Throws<ArgumentNullException>(() => eventStore.Save(@event));

                Assert.Equal(nameof(@event), ex.ParamName);
            }
        }

        [Fact]
        public void Save_NewAdministratorCreatedEvent_Should_Increment_EventsNumber()
        {
            using (var context = _fixtures.BuildContext())
            {
                var eventStore = new EventStore(context);
                
                var ev = new NewAdministratorCreatedEvent(Guid.NewGuid(), "Administrator2", "admin2@wilcommerce.com");
                eventStore.Save(ev);

                int count = eventStore.Find<NewAdministratorCreatedEvent>(DateTime.Now).Count();

                Assert.Equal(1, count);

                _fixtures.CleanAllData(context);
            }
        }
    }
}
