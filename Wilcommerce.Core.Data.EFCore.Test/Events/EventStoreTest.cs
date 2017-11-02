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
        public void Find_NewAdministratorCreatedEvent_Should_Return_1_Row_And_Match_Email_And_Name()
        {
            var events = _eventStore.Find<NewAdministratorCreatedEvent>(DateTime.Now);
            int count = events.Count();

            Assert.Equal(1, count);

            var ev = events.First();
            Assert.Equal("admin@wilcommerce.com", ev.Email);
            Assert.Equal("Administrator", ev.Name);
        }
    }
}
