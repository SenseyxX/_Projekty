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
    class QualityTypeConfiguration : IEntityTypeConfiguration<Quality>
    {
        private const string TableName = "Quality";

        public void Configure(EntityTypeBuilder<Quality> entityTypeBuilder)
        {
            entityTypeBuilder
                .ToTable(TableName, WarehouseContext.DefaultSchemaName)
                .HasKey(quality => quality.Id);

            entityTypeBuilder
                .Property<string>(nameof(Quality.Description))
                .HasMaxLength(30)
                .HasColumnName(nameof(Quality.Description))
                .IsRequired();
        }
    }
}
