using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Warehouse.Domain.Category.Enumeration;
using Warehouse.Domain.Item.Entities;
using Warehouse.Infrastructure.Persistence.Context;

namespace Warehouse.Infrastructure.Persistence.EntitiesConfiguration
{
    internal sealed class ItemTypeConfiguration : IEntityTypeConfiguration<Item>
    {
        private const string TableName = "Items";

        // Konfiguracja każdego propa w danej encji
        public void Configure(EntityTypeBuilder<Item> entityTypeBuilder)
        {
            entityTypeBuilder
                .ToTable(TableName, WarehouseContext.DefaultSchemaName) // Stworzenie Tabeli
                .HasKey(item => item.Id); // Dodanie klucza tabeli

            entityTypeBuilder
                .Property(nameof(Item.Name)) // Zdefiniownie że dany prop jest stringiem
                .HasMaxLength(50)   // Określenie maksymalnej ilości znaków w komórce
                .HasColumnName(nameof(Item.Name)) // Określenie Nazwy kolumny
                .IsRequired();      // Czy wartość w danej komórce jest wymagana

            entityTypeBuilder
                .Property(nameof(Item.Description))
                .HasMaxLength(1000)
                .HasColumnName(nameof(Item.Description))
                .IsRequired();

            entityTypeBuilder
                .Property(nameof(Item.QualityLevel))
                .HasColumnType("tinyint") // Zdefiniowanie typu komórki tinyint wartości od 0-255
                .HasColumnName(nameof(Item.QualityLevel))
                .IsRequired();

            entityTypeBuilder
               .Property(nameof(Item.Quantity))
               .HasColumnName(nameof(Item.Quantity))
               .IsRequired();

            entityTypeBuilder
                .Property(nameof(Item.CategoryState))
                .HasColumnType("tinyint")
                .HasColumnName(nameof(Item.CategoryState))
                .IsRequired();

            entityTypeBuilder
                .Property(nameof(Item.OwnerId))
                .HasColumnName(nameof(Item.OwnerId))
                .IsRequired(false);

            entityTypeBuilder
                .Property(nameof(Item.ActualOwnerId))
                .HasColumnName(nameof(Item.ActualOwnerId))
                .IsRequired();

            entityTypeBuilder
                .HasMany(item => item.LoanHistories) // Zdefiniowanie  zalezności pomiędzy encją Item a Loan history , Item posiada wiele LoanHistory
                .WithOne()    // Określenie że encja LoanHistory posiada tylko jeden item
                .HasForeignKey(loadHistory => loadHistory.ItemId); // Ustawienie ForeignKey

            entityTypeBuilder.HasQueryFilter(item => item.CategoryState != CategoryState.Deleted); // ToDo OPIS
        }
    }
}
