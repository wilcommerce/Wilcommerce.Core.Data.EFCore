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
        protected CommonContext _context;

        public EventStore(CommonContext context)
        {
            _context = context;
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
