using Microsoft.EntityFrameworkCore;
using Wilcommerce.Core.Common.Domain.Models;
using Wilcommerce.Core.Data.EFCore.Mapping;

namespace Wilcommerce.Core.Data.EFCore
{
    /// <summary>
    /// Defines the Entity Framework context for the common package
    /// </summary>
    public class CommonContext : DbContext
    {
        /// <summary>
        /// Get or set the list of users
        /// </summary>
        public virtual DbSet<User> Users { get; set; }

        /// <summary>
        /// Get or set the list of settings
        /// </summary>
        public virtual DbSet<GeneralSettings> Settings { get; set; }

        /// <summary>
        /// Construct the common context
        /// </summary>
        /// <param name="options">The context options</param>
        public CommonContext(DbContextOptions<CommonContext> options)
            : base(options)
        {

        }

        /// <summary>
        /// Override the <see cref="DbContext.OnModelCreating(ModelBuilder)"/>
        /// </summary>
        /// <param name="modelBuilder">The modelBuilder instance</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .MapUser()
                .MapSettings();

            base.OnModelCreating(modelBuilder);
        }
    }
}
