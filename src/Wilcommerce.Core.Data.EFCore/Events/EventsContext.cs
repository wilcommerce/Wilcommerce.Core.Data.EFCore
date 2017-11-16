using Microsoft.EntityFrameworkCore;
using Wilcommerce.Core.Common.Domain.Events;
using Wilcommerce.Core.Data.EFCore.Mapping;

namespace Wilcommerce.Core.Data.EFCore.Events
{
    /// <summary>
    /// Defines the Entity Framework context for the events
    /// </summary>
    public class EventsContext : DbContext
    {
        /// <summary>
        /// Get or set the events list
        /// </summary>
        public virtual DbSet<EventWrapper> Events { get; set; }

        /// <summary>
        /// Construct the events context
        /// </summary>
        /// <param name="options">The context options</param>
        public EventsContext(DbContextOptions<EventsContext> options)
            : base(options)
        {

        }

        /// <summary>
        /// Override the <see cref="DbContext.OnModelCreating(ModelBuilder)"/>
        /// </summary>
        /// <param name="modelBuilder">The modelBuilder instance</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.MapEvents();
            base.OnModelCreating(modelBuilder);
        }
    }
}
