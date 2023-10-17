using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Warehouse.Application.Services;
using Warehouse.Domain.Category.Enumeration;
using Warehouse.Domain.Squad.Entities;
using Warehouse.Domain.User.Entities;
using Warehouse.Infrastructure.Persistence.Context;

namespace Warehouse.Infrastructure.Persistence.EntitiesConfiguration
{
    internal sealed class UserTypeConfiguration : IEntityTypeConfiguration<User>
    {
        private const string TableName = "Users";
        private readonly IEncryptionService _encryptionService;

        public UserTypeConfiguration(IEncryptionService encryptionService)
        {
            _encryptionService = encryptionService;
        }
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
            
            entityTypeBuilder.HasData(
                new User(
                    Guid.Parse("eab0a7ad-8542-4e1a-8dd3-a8391edbf5f4"),
                    "Oskar",
                    "Gacki",
                     _encryptionService.EncodePassword("1234"),
                    "ogacki",
                    "888888888",
                    0,
                    State.Active,
                    Guid.Parse("1a0e19f9-8e92-41a1-9e92-09c587caef05"),
                    Guid.Parse("296f60db-9f13-48f3-853f-343de5ebdd20")
                    ),
                new User(
                    Guid.Parse("fa797f3e-b77a-4b92-a7e3-5aeba9aa4675"), 
                    "Szymon",
                    "Katryniok",
                    _encryptionService.EncodePassword("1234"),
                    "skatryniok",
                    "999999999",
                    0,
                    State.Active,
                    Guid.Parse("6251c1dc-58b9-43fa-bf01-098037d53bb6"), 
                    Guid.Parse("f7921a66-83b4-451d-8556-893882233118")
                    ),
                new User(
                    Guid.Parse("321a719b-b778-485f-8432-11f0f038cbce"), 
                    "Aleksander",
                    "Kijowski",
                    _encryptionService.EncodePassword("1234"),
                    "akijowski",
                    "777777777",
                    0,
                    State.Active,
                    Guid.Parse("c7d09645-cf24-4aca-93c1-96e8c97e4286"), 
                    Guid.Parse("d1401039-21d8-4a83-97e1-67dd2201e4a1")
                ),
                new User(
                    Guid.Parse("071c18c6-93e1-40ef-ae43-bdb3c8f2aab6"), 
                    "Wojtek",
                    "Patoń",
                    _encryptionService.EncodePassword("1234"),
                    "akijowski",
                    "666666666",
                    0,
                    State.Active,
                    Guid.Parse("1a0e19f9-8e92-41a1-9e92-09c587caef05"), 
                    Guid.Parse("296f60db-9f13-48f3-853f-343de5ebdd20")
                )
            );
        }
    }
}
