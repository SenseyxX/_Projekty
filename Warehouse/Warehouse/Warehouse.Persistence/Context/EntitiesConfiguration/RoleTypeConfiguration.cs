using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Warehouse.Persistence.Entities;
using Warehouse.Persistence.Entities.Role;

namespace Warehouse.Persistence.Context.EntitiesConfiguration
{
    internal sealed class RoleTypeConfiguration : IEntityTypeConfiguration<Role>
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

            entityTypeBuilder
                .Property<string>(nameof(Role.Description))
                .HasMaxLength(1000)
                .HasColumnName(nameof(Role.Description))
                .IsRequired();

            entityTypeBuilder
                 .Property<PerrmissionLevel>(nameof(Role.PermissionLevel))
                 .HasColumnType("tinyint")
                 .HasColumnName(nameof(Role.PermissionLevel));

        }
    }
}
