using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Warehouse.Persistence.Entities;
using Warehouse.Persistence.Entities.Item;

namespace Warehouse.Persistence.Context.EntitiesConfiguration
{
    internal sealed class CategoryTypeConfiguration : IEntityTypeConfiguration<Category>
    {
        private const string TableName = "Category";

        public void Configure(EntityTypeBuilder<Category> entityTypeBuilder)
        {
            entityTypeBuilder
                .ToTable(TableName, WarehouseContext.DefaultSchemaName)
                .HasKey(category => category.Id);

            entityTypeBuilder
                .Property<string>(nameof(Category.Name))
                .HasMaxLength(30)
                .HasColumnName(nameof(Category.Name))
                .IsRequired();

            entityTypeBuilder
                .Property<string>(nameof(Category.Description))
                .HasMaxLength(1000)
                .HasColumnName(nameof(Category.Description))
                .IsRequired();

            entityTypeBuilder
                .Property<State>(nameof(Category.State))
                .HasColumnType("tinyint")
                .HasColumnName(nameof(Category.State))
                .IsRequired();

            entityTypeBuilder
                .HasMany(category => category.Items)
                .WithOne()
                .HasForeignKey(item => item.CategoryId);
        }
    }
}
