﻿using Microsoft.EntityFrameworkCore;
using Wilcommerce.Core.Common.Domain.Events;
using Wilcommerce.Core.Common.Domain.Models;

namespace Wilcommerce.Core.Data.EFCore
{
    public class CommonContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<GeneralSettings> Settings { get; set; }

        public virtual DbSet<EventWrapper> Events { get; set; }

        public virtual DbSet<Currency> Currencies { get; set; }

        public virtual DbSet<Image> Images { get; set; }

        public virtual DbSet<SeoData> SeoData { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}