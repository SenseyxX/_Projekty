using Microsoft.EntityFrameworkCore;
using Warehouse.Persistence.Context.EntitiesConfiguration;
using Warehouse.Persistence.Entities;

namespace Warehouse.Persistence.Context
{
    public sealed class WarehouseContext : DbContext
    {
        public const string DefaultSchemaName = "Warehouse";

        public WarehouseContext(DbContextOptions<WarehouseContext> options)
            : base(options)
        {
        }

        public DbSet<Item> Items { get; init; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfiguration(new ItemTypeConfiguration());
        }
    }
}
