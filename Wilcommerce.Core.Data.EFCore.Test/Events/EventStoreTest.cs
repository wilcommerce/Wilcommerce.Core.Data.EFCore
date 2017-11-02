using System;
using System.Linq;
using Wilcommerce.Core.Common.Events.User;
using Wilcommerce.Core.Data.EFCore.Events;
using Wilcommerce.Core.Data.EFCore.Test.Fixtures;
using Xunit;

namespace Wilcommerce.Core.Data.EFCore.Test.Events
{
    public class EventStoreTest : IClassFixture<EventsFixtures>
    {
        private EventsFixtures _fixtures;

        private EventStore _eventStore;

        public EventStoreTest(EventsFixtures fixtures)
        {
            _fixtures = fixtures;
            _eventStore = new EventStore(_fixtures.Context);
        }

        [Fact]
        public void Find_NewAdministratorCreatedEvent_Should_Return_Rows_And_Match_Email_And_Name()
        {
            var events = _eventStore.Find<NewAdministratorCreatedEvent>(DateTime.Now);
            int count = events.Count();

            Assert.True(count > 0);

            bool exists = events.Any(e => e.Email == "admin@wilcommerce.com" && e.Name == "Administrator");
            Assert.True(exists);
        }

        [Fact]
        public void Save_NewAdministratorCreatedEvent_Should_Increment_EventsNumber()
        {
            int count = _eventStore.Find<NewAdministratorCreatedEvent>(DateTime.Now).Count();

            var ev = new NewAdministratorCreatedEvent(Guid.NewGuid(), "Administrator2", "admin2@wilcommerce.com");
            _eventStore.Save(ev);

            int newCount = _eventStore.Find<NewAdministratorCreatedEvent>(DateTime.Now).Count();

            Assert.Equal(count + 1, newCount);
        }
    }
}
