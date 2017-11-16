using Microsoft.EntityFrameworkCore;
using Wilcommerce.Core.Common.Domain.Models;

namespace Wilcommerce.Core.Data.EFCore.Mapping
{
    public static class GeneralSettingsMapping
    {
        /// <summary>
        /// Extension method. Maps the general settings class
        /// </summary>
        /// <param name="modelBuilder">The modelBuilder instance</param>
        /// <returns>The modelBuilder instance</returns>
        public static ModelBuilder MapSettings(this ModelBuilder modelBuilder)
        {
            var settingsMapping = modelBuilder.Entity<GeneralSettings>();
            settingsMapping.ToTable("Wilcommerce_GeneralSettings");

            settingsMapping.OwnsOne(s => s.Seo);
            settingsMapping.OwnsOne(s => s.Favicon);
            settingsMapping.OwnsOne(s => s.SiteLogo);

            return modelBuilder;
        }
    }
}
