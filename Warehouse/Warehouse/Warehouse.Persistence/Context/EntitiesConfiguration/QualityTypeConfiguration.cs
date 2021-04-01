using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Warehouse.Persistence.Entities.Quality;

namespace Warehouse.Persistence.Context.EntitiesConfiguration
{
    internal sealed class QualityTypeConfiguration : IEntityTypeConfiguration<Quality>
    {
        private const string TableName = "Quality";

        public void Configure(EntityTypeBuilder<Quality> entityTypeBuilder)
        {
            entityTypeBuilder
                .ToTable(TableName, WarehouseContext.DefaultSchemaName)
                .HasKey(quality => quality.Id);

            entityTypeBuilder
                .Property<QualityLevel>(nameof(Quality.QualityLevel))
                .HasColumnType("tinyint")
                .HasColumnName(nameof(Quality.QualityLevel));

            entityTypeBuilder
                .Property<string>(nameof(Quality.Description))
                .HasMaxLength(30)
                .HasColumnName(nameof(Quality.Description))
                .IsRequired();
        }
    }
}
