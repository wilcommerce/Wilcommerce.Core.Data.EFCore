using Microsoft.EntityFrameworkCore;
using Wilcommerce.Core.Common.Events;

namespace Wilcommerce.Core.Data.EFCore.Mapping
{
    /// <summary>
    /// Defines the modelBuilder's extension methods to map the <see cref="EventWrapper"/> class
    /// </summary>
    public static class EventMapping
    {
        /// <summary>
        /// Extension method. Maps the event class
        /// </summary>
        /// <param name="modelBuilder">The modelBuilder instance</param>
        /// <returns>The modelBuilder instance</returns>
        public static ModelBuilder MapEvents(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventWrapper>()
                .ToTable("Wilcommerce_Events")
                .HasKey(e => e.Id);

            modelBuilder.Entity<EventWrapper>()
                .Ignore(e => e.Event);

            return modelBuilder;
        }
    }
}
