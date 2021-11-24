using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Warehouse.Domain.Item.Entities;
using Warehouse.Infrastructure.Persistence.Context;

namespace Warehouse.Infrastructure.Persistence.EntitiesConfiguration
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
                .Property(nameof(LoanHistory.Timestamp))
                .HasColumnName(nameof(LoanHistory.Timestamp))
                .IsRequired();

            entityTypeBuilder
                .Property(nameof(LoanHistory.ItemId))
                .HasColumnName(nameof(LoanHistory.ItemId))
                .IsRequired();

            entityTypeBuilder
                .Property(nameof(LoanHistory.BorrowerId))
                .HasColumnName(nameof(LoanHistory.BorrowerId))
                .IsRequired();

            entityTypeBuilder
                .Property(nameof(LoanHistory.ReceiverId))
                .HasColumnName(nameof(LoanHistory.ReceiverId))
                .IsRequired();
        }
    }
}
