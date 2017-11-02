using Microsoft.EntityFrameworkCore;
using Wilcommerce.Core.Common.Domain.Events;
using Wilcommerce.Core.Common.Domain.Models;
using Wilcommerce.Core.Data.EFCore.Mapping;

namespace Wilcommerce.Core.Data.EFCore
{
    public class CommonContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<GeneralSettings> Settings { get; set; }

        public CommonContext(DbContextOptions<CommonContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .MapUser()
                .MapSettings()
                .MapEvents();

            base.OnModelCreating(modelBuilder);
        }
    }
}
