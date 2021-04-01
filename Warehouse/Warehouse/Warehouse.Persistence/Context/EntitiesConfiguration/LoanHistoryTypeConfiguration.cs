using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using Warehouse.Persistence.Entities;

namespace Warehouse.Persistence.Context.EntitiesConfiguration
{
    internal sealed class LoanHistoryTypeConfiguration : IEntityTypeConfiguration<LoanHistory>
    {
        private const string TableName = "LoanHistories";

        public void Configure(EntityTypeBuilder<LoanHistory> entityTypeBuilder)
        {
            entityTypeBuilder
                .ToTable(TableName, WarehouseContext.DefaultSchemaName)
                .HasKey(loanHistory => loanHistory.Id);

            entityTypeBuilder
                .Property<DateTime>(nameof(LoanHistory.Timestamp))
                .HasColumnName(nameof(LoanHistory.Timestamp));

            entityTypeBuilder
                .Property<Guid>(nameof(LoanHistory.ItemId))
                .HasColumnName(nameof(LoanHistory.ItemId));

            entityTypeBuilder
                .Property<Guid>(nameof(LoanHistory.BorrowerId))
                .HasColumnName(nameof(LoanHistory.BorrowerId));

            entityTypeBuilder
                .Property<Guid>(nameof(LoanHistory.ReceiverId))
                .HasColumnName(nameof(LoanHistory.ReceiverId));

        }
    }
}
