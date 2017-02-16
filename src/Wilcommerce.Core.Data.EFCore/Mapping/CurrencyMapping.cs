using Microsoft.EntityFrameworkCore;
using Wilcommerce.Core.Common.Domain.Models;

namespace Wilcommerce.Core.Data.EFCore.Mapping
{
    public static class CurrencyMapping
    {
        public static ModelBuilder MapCurrencies(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Currency>()
                .ToTable("Wilcommerce_Currencies")
                .Property(c => c.Id)
                .ValueGeneratedOnAdd();

            return modelBuilder;
        }
    }
}
