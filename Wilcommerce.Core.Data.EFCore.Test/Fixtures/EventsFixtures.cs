using Microsoft.EntityFrameworkCore;
using System;
using Wilcommerce.Core.Common.Events;

namespace Wilcommerce.Core.Data.EFCore.Test.Fixtures
{
    public class EventsFixtures : IDisposable
    {
        public EventsContext Context { get; protected set; }

        public Guid UserId { get; protected set; }

        public EventsFixtures()
        {
            UserId = Guid.NewGuid();

            BuildContext();
            PrepareData();
        }

        public void Dispose()
        {
            CleanData();

            if (Context != null)
            {
                Context.Dispose();
            }

            GC.SuppressFinalize(this);
        }

        protected virtual void PrepareData()
        {
            var administratorCreatedEvent = new NewAdministratorCreatedEvent(UserId, "Administrator", "admin@wilcommerce.com");
            Context.Events.Add(EventWrapper.Wrap(administratorCreatedEvent));

            for (int i = 0; i < 3; i++)
            {
                var ev = new UserEnabledEvent(UserId);
                Context.Events.Add(EventWrapper.Wrap(ev));
            }

            for (int i = 0; i < 2; i++)
            {
                var ev = new UserDisabledEvent(UserId);
                Context.Events.Add(EventWrapper.Wrap(ev));
            }

            Context.SaveChanges();
        }

        protected virtual void CleanData()
        {
            Context.Events.RemoveRange(Context.Events);
        }

        protected virtual void BuildContext()
        {
            var options = new DbContextOptionsBuilder<EventsContext>()
                .UseInMemoryDatabase(databaseName: "InMemory-Events")
                .Options;

            Context = new EventsContext(options);
        }
    }
}
