using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wilcommerce.Core.Common.Events;

namespace Wilcommerce.Core.Data.EFCore.Mapping
{
    /// <summary>
    /// Implementation of <see cref="IEntityTypeConfiguration{TEntity}"/> for the EventWrapper class
    /// </summary>
    public class EventMapper : IEntityTypeConfiguration<EventWrapper>
    {
        /// <summary>
        /// Implementation of <see cref="IEntityTypeConfiguration{TEntity}.Configure(EntityTypeBuilder{TEntity})"/> for the EventWrapper class
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<EventWrapper> builder)
        {
            builder.ToTable("Wilcommerce_Events")
                .HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .ValueGeneratedNever();

            builder.Ignore(e => e.Event);
        }
    }
}
