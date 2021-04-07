using Microsoft.EntityFrameworkCore;
using Warehouse.Persistence.Context.EntitiesConfiguration;
using Warehouse.Persistence.Entities;
using Warehouse.Persistence.Entities.Quality;
using Warehouse.Persistence.Entities.Role;

namespace Warehouse.Persistence.Context
{
    public sealed class WarehouseContext : DbContext
    {
        public const string DefaultSchemaName = "Warehouse";

        public WarehouseContext(DbContextOptions<WarehouseContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; init; }
        public DbSet<Item> Items { get; init; }
        public DbSet<LoanHistory> LoanHistories { get; init; }
        public DbSet<Quality>Qualities  { get; init; }
        public DbSet<Role>Roles  { get; init; }
        public DbSet<Squad>Squads  { get; init; }
        public DbSet<User> Users { get; init; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
            => modelBuilder
                .ApplyConfiguration(new CategoryTypeConfiguration())
                .ApplyConfiguration(new ItemTypeConfiguration())
                .ApplyConfiguration(new LoanHistoryTypeConfiguration())
                .ApplyConfiguration(new QualityTypeConfiguration())
                .ApplyConfiguration(new RoleTypeConfiguration())
                .ApplyConfiguration(new SquadTypeConfiguration())
                .ApplyConfiguration(new UserTypeConfiguration());
    }
}
