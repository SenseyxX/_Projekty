using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Warehouse.Persistence.Entities;
using Warehouse.Persistence.Entities.Item;
using Warehouse.Persistence.Entities.Item.Entities;

namespace Warehouse.Persistence.Context.EntitiesConfiguration
{
    internal sealed class ItemTypeConfiguration : IEntityTypeConfiguration<Item>
    {
        private const string TableName = "Items";

        public void Configure(EntityTypeBuilder<Item> entityTypeBuilder)
        {
            entityTypeBuilder
                .ToTable(TableName, WarehouseContext.DefaultSchemaName)
                .HasKey(item => item.Id);

            entityTypeBuilder
                .Property<string>(nameof(Item.Name))
                .HasMaxLength(50)
                .HasColumnName(nameof(Item.Name))
                .IsRequired();

            entityTypeBuilder
                .Property<string>(nameof(Item.Description))
                .HasMaxLength(1000)
                .HasColumnName(nameof(Item.Description))
                .IsRequired();

            entityTypeBuilder
                .Property<QualityLevel>(nameof(Item.QualityLevel))
                .HasColumnType("tinyint")
                .HasColumnName(nameof(Item.QualityLevel))
                .IsRequired();

            entityTypeBuilder
                .Property<ItemState>(nameof(Item.ItemState))
                .HasColumnType("tinyint")
                .HasColumnName(nameof(Item.ItemState))
                .IsRequired();

            entityTypeBuilder
                .Property<Guid?>(nameof(Item.OwnerId))
                .HasColumnName(nameof(Item.OwnerId))
                .IsRequired();

            entityTypeBuilder
                .Property<Guid>(nameof(Item.ActualOwnerId))
                .HasColumnName(nameof(Item.ActualOwnerId))
                .IsRequired();

            entityTypeBuilder
                .HasMany(item => item.LoanHistories)
                .WithOne()
                .HasForeignKey(loadHistory => loadHistory.ItemId);

            entityTypeBuilder.HasQueryFilter(item => item.ItemState != ItemState.Deleted);
        }
    }
}
