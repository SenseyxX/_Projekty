using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Persistence.Entities;

namespace Warehouse.Persistence.Context.EntitiesConfiguration
{
    class CategoryTypeConfiguration:IEntityTypeConfiguration<Category>
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
        }
    }
}
