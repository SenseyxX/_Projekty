﻿using Microsoft.EntityFrameworkCore;
using Warehouse.Persistence.Context.EntitiesConfiguration;
using Warehouse.Persistence.Entities;
using Warehouse.Persistence.Entities.Item.Entities;
using Warehouse.Persistence.Entities.User.Entities;

namespace Warehouse.Persistence.Context
{
    public sealed class WarehouseContext : DbContext
    {
        public const string DefaultSchemaName = "Warehouse";  

        public WarehouseContext(DbContextOptions<WarehouseContext> options)
            : base(options)
        {
        }
        
        // Inicjowanie encji w context
        public DbSet<Category> Categories { get; init; }
        public DbSet<Item> Items { get; init; }
        public DbSet<LoanHistory> LoanHistories { get; init; }
        public DbSet<Squad>Squads  { get; init; }
        public DbSet<User> Users { get; init; }

        // Inicjowanie plików konfiguracyjnych encje
        protected override void OnModelCreating(ModelBuilder modelBuilder)
            => modelBuilder
                .ApplyConfiguration(new CategoryTypeConfiguration())
                .ApplyConfiguration(new ItemTypeConfiguration())
                .ApplyConfiguration(new LoanHistoryTypeConfiguration())
                .ApplyConfiguration(new SquadTypeConfiguration())
                .ApplyConfiguration(new UserTypeConfiguration())
                .ApplyConfiguration(new TeamTypeConfiguration())
                .ApplyConfiguration(new DuesTypeConfiguration());
    }
}
