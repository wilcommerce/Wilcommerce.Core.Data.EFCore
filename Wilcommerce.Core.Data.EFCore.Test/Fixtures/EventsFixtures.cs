using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Wilcommerce.Core.Common.Events;
using Wilcommerce.Core.Infrastructure;

namespace Wilcommerce.Core.Data.EFCore.Test.Fixtures
{
    public class EventsFixtures : IDisposable
    {
        public Guid UserId { get; protected set; }

        private DbContextOptions<EventsContext> _contextOptions;

        public EventsFixtures()
        {
            UserId = Guid.NewGuid();
            BuildContextOptions();
        }

        public EventsContext BuildContext()
        {
            return new EventsContext(this._contextOptions);
        }

        public void PrepareData(EventsContext context, IEnumerable<DomainEvent> events)
        {
            if (events != null && events.Count() > 0)
            {
                var eventsWrapped = events.Select(ev => EventWrapper.Wrap(ev)).ToArray();
                context.AddRange(eventsWrapped);

                context.SaveChanges();
            }
        }

        public void CleanAllData(EventsContext context)
        {
            context.RemoveRange(context.Events);
            context.SaveChanges();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        protected virtual void BuildContextOptions()
        {
            var options = new DbContextOptionsBuilder<EventsContext>()
                .UseInMemoryDatabase(databaseName: "InMemory-Events")
                .Options;

            this._contextOptions = options;
        }
    }
}
