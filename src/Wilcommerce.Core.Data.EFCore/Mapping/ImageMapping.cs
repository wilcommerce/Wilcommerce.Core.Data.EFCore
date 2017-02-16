using Microsoft.EntityFrameworkCore;
using Wilcommerce.Core.Common.Domain.Models;

namespace Wilcommerce.Core.Data.EFCore.Mapping
{
    public static class ImageMapping
    {
        public static ModelBuilder MapImages(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Image>()
                .ToTable("Wilcommerce_Images")
                .Property(i => i.Id)
                .ValueGeneratedOnAdd();

            return modelBuilder;
        }
    }
}
