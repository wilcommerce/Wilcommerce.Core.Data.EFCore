using Wilcommerce.Core.Common.Domain.Events;
using Wilcommerce.Core.Infrastructure;

namespace Wilcommerce.Core.Data.EFCore.Events
{
    public class EventStore : IEventStore
    {
        public void Save<TEvent>(TEvent @event) where TEvent : DomainEvent
        {
            using (var context = new CommonContext())
            {
                try
                {
                    var ev = EventWrapper.Wrap(@event);
                    context.Events.Add(ev);

                    context.SaveChanges();
                }
                catch 
                {
                    throw;
                }
            }
        }
    }
}
