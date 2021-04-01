using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Warehouse.Persistence.Entities;

namespace Warehouse.Persistence.Context.EntitiesConfiguration
{
    internal sealed class UserTypeConfiguration : IEntityTypeConfiguration<User>
    {
        private const string TableName = "Users";

        public void Configure(EntityTypeBuilder<User> entityTypeBuilder)
        {
            entityTypeBuilder
                .ToTable(TableName, WarehouseContext.DefaultSchemaName)
                .HasKey(user => user.Id);

            entityTypeBuilder
                .Property<string>(nameof(User.Name))
                .HasMaxLength(30)
                .HasColumnName(nameof(User.Name))
                .IsRequired();

            entityTypeBuilder
                .Property<string>(nameof(User.LastName))
                .HasMaxLength(30)
                .HasColumnName(nameof(User.LastName))
                .IsRequired();

            entityTypeBuilder
                .Property<string>(nameof(User.PasswordHash))
                .HasMaxLength(100)
                .HasColumnName(nameof(User.PasswordHash))
                .IsRequired();

            entityTypeBuilder
                .Property<string>(nameof(User.Email))
                .HasMaxLength(50)
                .HasColumnName(nameof(User.Email))
                .IsRequired();

            entityTypeBuilder
                .Property<string>(nameof(User.PhoneNumber))
                .HasMaxLength(15)
                .HasColumnName(nameof(User.PhoneNumber))
                .IsRequired();

            entityTypeBuilder
                .Property<Guid>(nameof(User.RoleId))
                .HasColumnName(nameof(User.RoleId))
                .IsRequired();

            entityTypeBuilder
                .HasOne(user => user.Role)
                .WithMany()
                .HasForeignKey(user => user.RoleId);

            entityTypeBuilder
                .HasMany(user => user.OwnedItems)
                .WithOne()
                .HasForeignKey(item => item.ActualOwnerId)
                .OnDelete(DeleteBehavior.Cascade);

            entityTypeBuilder
                .HasMany(user => user.StoredItems)
                .WithOne()
                .HasForeignKey(item => item.OwnerId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

