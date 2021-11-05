using Microsoft.EntityFrameworkCore;
using Warehouse.Domain.Category.Entities;
using Warehouse.Domain.Item.Entities;
using Warehouse.Domain.Rental.Entities;
using Warehouse.Domain.Squad.Entities;
using Warehouse.Domain.User.Entities;
using Warehouse.Infrastructure.Persistence.EntitiesConfiguration;

namespace Warehouse.Infrastructure.Persistence.Context
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
        public DbSet<Due> Dues { get; init; }
        public DbSet<Item> Items { get; init; }
        public DbSet<LoanHistory> LoanHistories { get; init; }
        public DbSet<Rental> Rentals { get; init; }
        public DbSet<RentalItem> RentalItems { get; init; }
        public DbSet<Squad>Squads  { get; init; }
        public DbSet<User> Users { get; init; }
        public DbSet<Team> Teams { get; init; }


        // Inicjowanie plików konfiguracyjnych encje
        protected override void OnModelCreating(ModelBuilder modelBuilder)
            => modelBuilder
                .ApplyConfiguration(new CategoryTypeConfiguration())
                .ApplyConfiguration(new DueTypeConfiguration())
                .ApplyConfiguration(new ItemTypeConfiguration())
                .ApplyConfiguration(new LoanHistoryTypeConfiguration())
                .ApplyConfiguration(new RentalTypeConfiguration())
                .ApplyConfiguration(new RentalItemTypeConfiguration())
                .ApplyConfiguration(new SquadTypeConfiguration())
                .ApplyConfiguration(new UserTypeConfiguration())
                .ApplyConfiguration(new TeamTypeConfiguration());
    }
}
