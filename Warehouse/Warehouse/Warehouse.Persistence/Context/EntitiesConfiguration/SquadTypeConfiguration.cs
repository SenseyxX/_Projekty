using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Warehouse.Persistence.Entities;

namespace Warehouse.Persistence.Context.EntitiesConfiguration
{
    internal sealed class SquadTypeConfiguration : IEntityTypeConfiguration<Squad>
    {
        private const string TableName = "Squads";

        public void Configure(EntityTypeBuilder<Squad> entityTypeBuilder)
        {
            entityTypeBuilder
                .ToTable(TableName, WarehouseContext.DefaultSchemaName)
                .HasKey(squad => squad.Id);

            entityTypeBuilder
                .Property<string>(nameof(Squad.Name))
                .HasMaxLength(30)
                .HasColumnName(nameof(Squad.Name))
                .IsRequired();

            entityTypeBuilder
                .Property<State>(nameof(Squad.State))
                .HasColumnType("tinyint")
                .HasColumnName(nameof(Squad.State))
                .IsRequired();

            entityTypeBuilder
                .HasMany(squad => squad.Users)
                .WithOne()
                .HasForeignKey(user => user.SquadId);
        }
    }
}
