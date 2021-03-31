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
    class SquadTypeConfiguration : IEntityTypeConfiguration<Squad>
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
        }
    }
}
