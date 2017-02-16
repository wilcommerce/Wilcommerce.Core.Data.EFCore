using Microsoft.EntityFrameworkCore;
using Wilcommerce.Core.Common.Domain.Models;

namespace Wilcommerce.Core.Data.EFCore.Mapping
{
    public static class SeoDataMapping
    {
        public static ModelBuilder MapSeo(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SeoData>()
                .ToTable("Wilcommerce_SeoData")
                .Property(s => s.Id)
                .ValueGeneratedOnAdd();

            return modelBuilder;
        }
    }
}
