using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Wilcommerce.Core.Common.Events;
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

        /// <summary>
        /// Implementation of <see cref="IEventStore.Find{TEvent}(DateTime)"/>
        /// </summary>
        /// <typeparam name="TEvent">The event's type to search for</typeparam>
        /// <param name="timestamp">by which filters the event's list</param>
        /// <returns>A list of events</returns>
        public IEnumerable<TEvent> Find<TEvent>(DateTime timestamp) where TEvent : DomainEvent
        {
            var eventType = typeof(TEvent);
            string eventTypeString = eventType.ToString();

            var events = _FindBy(e => e.EventType == eventTypeString && e.Timestamp <= timestamp);

            return events
                .AsEnumerable()
                .Select(e => e.Event as TEvent);
        }

        /// <summary>
        /// Implementation of <see cref="IEventStore.Find{TEvent}(string, DateTime)"/>
        /// </summary>
        /// <typeparam name="TEvent">The event's type to search for</typeparam>
        /// <param name="entityType">The entity type which fired the events</param>
        /// <param name="timestamp">The timestamp by which filters the event's list</param>
        /// <returns>A list of events</returns>
        public IEnumerable<TEvent> Find<TEvent>(string entityType, DateTime timestamp) where TEvent : DomainEvent
        {
            var eventType = typeof(TEvent);
            string eventTypeString = eventType.ToString();

            var events = _FindBy(e => e.EventType == eventTypeString && e.AggregateType == entityType && e.Timestamp <= timestamp);

            return events
                .AsEnumerable()
                .Select(e => e.Event as TEvent);
        }

        /// <summary>
        /// Implementation of <see cref="IEventStore.Find{TEvent}(string, Guid, DateTime)"/>
        /// </summary>
        /// <typeparam name="TEvent">The event's type to search for</typeparam>
        /// <param name="entityType">The entity type which fired the events</param>
        /// <param name="entityId">The id of the entity which fired the events</param>
        /// <param name="timestamp">The timestamp by which filters the event's list</param>
        /// <returns>A list of events</returns>
        public IEnumerable<TEvent> Find<TEvent>(string entityType, Guid entityId, DateTime timestamp) where TEvent : DomainEvent
        {
            var eventType = typeof(TEvent);
            string eventTypeString = eventType.ToString();

            var events = _FindBy(e => e.EventType == eventTypeString && e.AggregateType == entityType && e.AggregateId == entityId && e.Timestamp <= timestamp);

            return events
                .AsEnumerable()
                .Select(e => e.Event as TEvent);
        }

        /// <summary>
        /// Implementation of <see cref="IEventStore.FindAll(string, Guid, DateTime)"/>
        /// </summary>
        /// <param name="entityType">The entity type which fired the events</param>
        /// <param name="entityId">The id of the entity which fired the events</param>
        /// <param name="timestamp">The timestamp by which filters the event's list</param>
        /// <returns>The list of occured events</returns>
        public IEnumerable<DomainEvent> FindAll(string entityType, Guid entityId, DateTime timestamp)
        {
            var events = _FindBy(e => e.AggregateType == entityType && e.AggregateId == entityId && e.Timestamp <= timestamp);

            return events
                .AsEnumerable()
                .Select(e => e.Event as DomainEvent);
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

        #region Protected Methods
        /// <summary>
        /// Find a list of event wrapper by the specified criteria
        /// </summary>
        /// <param name="criteria">The criteria to apply</param>
        /// <returns>The list of event wrapper</returns>
        protected virtual IQueryable<EventWrapper> _FindBy(Expression<Func<EventWrapper, bool>> criteria)
        {
            if (criteria == null)
            {
                throw new ArgumentException("criteria");
            }

            return _context.Events
                .Where(criteria)
                .OrderByDescending(e => e.Timestamp);
        }
        #endregion
    }
}
