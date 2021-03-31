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
    class RoleTypeConfiguration : IEntityTypeConfiguration<Role>
    {
        private const string TableName = "Roles";
        public void Configure(EntityTypeBuilder<Role> entityTypeBuilder)
        {
            entityTypeBuilder
                .ToTable(TableName, WarehouseContext.DefaultSchemaName)
                .HasKey(role => role.Id);

            entityTypeBuilder
                .Property<string>(nameof(Role.Name))
                .HasMaxLength(30)
                .HasColumnName(nameof(Role.Name))
                .IsRequired();
        }
    }
}
