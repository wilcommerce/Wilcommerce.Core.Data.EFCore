using Microsoft.EntityFrameworkCore;
using Wilcommerce.Core.Common.Domain.Models;

namespace Wilcommerce.Core.Data.EFCore.Mapping
{
    public static class UserMapping
    {
        /// <summary>
        /// Extension method. Maps the user class
        /// </summary>
        /// <param name="modelBuilder">The modelBuilder instance</param>
        /// <returns>The modelBuilder instance</returns>
        public static ModelBuilder MapUser(this ModelBuilder modelBuilder)
        {
            var userMapping = modelBuilder.Entity<User>();

            userMapping
                .ToTable("Wilcommerce_Users")
                .HasIndex(u => u.Email).IsUnique();

            userMapping.HasOne(u => u.ProfileImage);

            return modelBuilder;
        }
    }
}
