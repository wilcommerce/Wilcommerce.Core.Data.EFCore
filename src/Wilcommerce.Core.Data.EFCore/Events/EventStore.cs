using System;
using System.Collections.Generic;
using Wilcommerce.Core.Common.Domain.Events;
using Wilcommerce.Core.Infrastructure;

namespace Wilcommerce.Core.Data.EFCore.Events
{
    /// <summary>
    /// Implementation of <see cref="IEventStore"/>
    /// </summary>
    public class EventStore : IEventStore
    {
        /// <summary>
        /// The DbContext instance
        /// </summary>
        protected EventsContext _context;

        /// <summary>
        /// Construct the event store
        /// </summary>
        /// <param name="context">The db context instance</param>
        public EventStore(EventsContext context)
        {
            _context = context;
        }

        public IEnumerable<TEvent> Find<TEvent>(DateTime timestamp) where TEvent : DomainEvent
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEvent> Find<TEvent>(string entityType, DateTime timestamp) where TEvent : DomainEvent
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEvent> Find<TEvent>(string entityType, Guid entityId, DateTime timestamp) where TEvent : DomainEvent
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DomainEvent> FindAll(string entityType, Guid entityId, DateTime timestamp)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Saves the specified event
        /// </summary>
        /// <typeparam name="TEvent">The type of the event to save</typeparam>
        /// <param name="event">The event to save</param>
        public void Save<TEvent>(TEvent @event) where TEvent : DomainEvent
        {
            try
            {
                var ev = EventWrapper.Wrap(@event);
                _context.Events.Add(ev);

                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}
