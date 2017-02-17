using Wilcommerce.Core.Common.Domain.Events;
using Wilcommerce.Core.Infrastructure;

namespace Wilcommerce.Core.Data.EFCore.Events
{
    public class EventStore : IEventStore
    {
        protected CommonContext _context;

        public EventStore(CommonContext context)
        {
            _context = context;
        }

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
