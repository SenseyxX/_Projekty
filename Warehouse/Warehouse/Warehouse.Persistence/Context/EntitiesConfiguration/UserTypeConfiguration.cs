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
    public sealed class UserTypeConfiguration : IEntityTypeConfiguration<User>
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

        }
    }
}

