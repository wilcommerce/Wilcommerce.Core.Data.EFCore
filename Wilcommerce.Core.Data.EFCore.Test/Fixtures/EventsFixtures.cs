using Microsoft.EntityFrameworkCore;
using System;
using Wilcommerce.Core.Common.Domain.Events;
using Wilcommerce.Core.Common.Events.User;
using Wilcommerce.Core.Data.EFCore.Events;

namespace Wilcommerce.Core.Data.EFCore.Test.Fixtures
{
    public class EventsFixtures : IDisposable
    {
        public EventsContext Context { get; protected set; }

        public EventsFixtures()
        {
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
            var administratorCreatedEvent = new NewAdministratorCreatedEvent(Guid.NewGuid(), "Administrator", "admin@wilcommerce.com");
            Context.Events.Add(EventWrapper.Wrap(administratorCreatedEvent));

            for (int i = 0; i < 3; i++)
            {
                var ev = new UserEnabledEvent(Guid.NewGuid());
                Context.Events.Add(EventWrapper.Wrap(ev));
            }

            for (int i = 0; i < 2; i++)
            {
                var ev = new UserDisabledEvent(Guid.NewGuid());
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
