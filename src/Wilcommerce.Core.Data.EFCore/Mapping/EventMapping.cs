using Microsoft.EntityFrameworkCore;
using Wilcommerce.Core.Common.Domain.Events;

namespace Wilcommerce.Core.Data.EFCore.Mapping
{
    public static class EventMapping
    {
        public static ModelBuilder MapEvents(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventWrapper>()
                .ToTable("Wilcommerce_Events")
                .HasKey(e => e.Id);

            return modelBuilder;
        }
    }
}
