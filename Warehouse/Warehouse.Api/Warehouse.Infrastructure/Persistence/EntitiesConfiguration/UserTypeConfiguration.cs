﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Warehouse.Domain.User.Entities;
using Warehouse.Infrastructure.Persistence.Context;

namespace Warehouse.Infrastructure.Persistence.EntitiesConfiguration
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
                .Property(nameof(User.Name))
                .HasMaxLength(30)
                .HasColumnName(nameof(User.Name))
                .IsRequired();

            entityTypeBuilder
                .Property(nameof(User.LastName))
                .HasMaxLength(30)
                .HasColumnName(nameof(User.LastName))
                .IsRequired();

            entityTypeBuilder
                .Property(nameof(User.SquadId))
                .HasColumnName(nameof(User.SquadId))
                .IsRequired(false);

            entityTypeBuilder
                .Property<byte[]>(nameof(User.PasswordHash))
                .HasMaxLength(256)
                .HasColumnName(nameof(User.PasswordHash))
                .IsRequired();

            entityTypeBuilder
                .Property(nameof(User.Email))
                .HasMaxLength(50)
                .HasColumnName(nameof(User.Email))
                .IsRequired();

            entityTypeBuilder
                .Property(nameof(User.PhoneNumber))
                .HasMaxLength(15)
                .HasColumnName(nameof(User.PhoneNumber))
                .IsRequired();

            entityTypeBuilder
                .Property(nameof(User.State))
                .HasColumnType("tinyint")
                .HasColumnName(nameof(User.State))
                .IsRequired();

            entityTypeBuilder
                .Property(nameof(User.PermissionLevel))
                .HasColumnType("tinyint")
                .HasColumnName(nameof(User.PermissionLevel))
                .IsRequired();

            entityTypeBuilder
                .Property(nameof(User.TeamId))
                .HasColumnName(nameof(User.TeamId))
                .HasDefaultValue(null)
                .IsRequired(false);

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

            entityTypeBuilder
                .HasMany(user => user.Dues)
                .WithOne()
                .HasForeignKey(due => due.UserId);
        }
    }
}
