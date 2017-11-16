﻿using Microsoft.EntityFrameworkCore;
using Wilcommerce.Core.Common.Domain.Events;
using Wilcommerce.Core.Data.EFCore.Mapping;

namespace Wilcommerce.Core.Data.EFCore.Events
{
    public class EventsContext : DbContext
    {
        public virtual DbSet<EventWrapper> Events { get; set; }

        public EventsContext(DbContextOptions<EventsContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.MapEvents();
            base.OnModelCreating(modelBuilder);
        }
    }
}