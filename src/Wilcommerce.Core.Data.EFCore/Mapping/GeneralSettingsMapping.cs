using Microsoft.EntityFrameworkCore;
using Wilcommerce.Core.Common.Domain.Models;

namespace Wilcommerce.Core.Data.EFCore.Mapping
{
    public static class GeneralSettingsMapping
    {
        public static ModelBuilder MapSettings(this ModelBuilder modelBuilder)
        {
            var settingsMapping = modelBuilder.Entity<GeneralSettings>();
            settingsMapping.ToTable("Wilcommerce_GeneralSettings");

            settingsMapping.HasOne(s => s.Seo);
            settingsMapping.HasOne(s => s.Favicon);
            settingsMapping.HasOne(s => s.SiteLogo);

            return modelBuilder;
        }
    }
}
