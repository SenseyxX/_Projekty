using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Warehouse.Domain.Rental.Entities;
using Warehouse.Infrastructure.Persistence.Context;

namespace Warehouse.Infrastructure.Persistence.EntitiesConfiguration
{
    internal sealed class RentalTypeConfiguration : IEntityTypeConfiguration<Rental>
    {
        private const string TableName = "Rental";

        public void Configure(EntityTypeBuilder<Rental> entityTypeBuilder)
        {
            entityTypeBuilder
                .ToTable(TableName, WarehouseContext.DefaultSchemaName)
                .HasKey(rental => rental.Id);

            entityTypeBuilder
                .Property(nameof(Rental.UserId))
                .HasColumnName(nameof(Rental.UserId))
                .IsRequired();

            entityTypeBuilder
                .Property(nameof(Rental.RentalStatus))
                .HasColumnName(nameof(Rental.RentalStatus))
                .IsRequired();

            entityTypeBuilder
                .HasMany(rental => rental.RentalItems)
                .WithOne()
                .HasForeignKey(rentalItem => rentalItem.Id);
        }
    }
}