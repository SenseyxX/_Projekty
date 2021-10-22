using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Warehouse.Domain.Rental.Entities;
using Warehouse.Infrastructure.Persistence.Context;

namespace Warehouse.Infrastructure.Persistence.EntitiesConfiguration
{
    internal sealed class RentalItemTypeConfiguration : IEntityTypeConfiguration<RentalItem>
    {
        private const string TableName = "RentalItems";
        
        public void Configure(EntityTypeBuilder<RentalItem> entityTypeBuilder)
        {
            entityTypeBuilder
                .ToTable(TableName, WarehouseContext.DefaultSchemaName)
                .HasKey(rentalItem => rentalItem.Id);

            entityTypeBuilder
                .Property(nameof(RentalItem.RentalItemCode))
                .HasColumnName(nameof(RentalItem.RentalItemCode))
                .IsRequired();

            entityTypeBuilder
                .Property(nameof(RentalItem.RentalItemStatus))
                .HasColumnName(nameof(RentalItem.RentalItemStatus))
                .IsRequired();
        }
    }
}