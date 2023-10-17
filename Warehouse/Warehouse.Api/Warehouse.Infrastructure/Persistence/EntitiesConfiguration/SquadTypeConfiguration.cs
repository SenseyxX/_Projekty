using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Warehouse.Domain.Category.Enumeration;
using Warehouse.Domain.Squad.Entities;
using Warehouse.Infrastructure.Persistence.Context;

namespace Warehouse.Infrastructure.Persistence.EntitiesConfiguration
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
                .Property(nameof(Squad.Name))
                .HasMaxLength(30)
                .HasColumnName(nameof(Squad.Name))
                .IsRequired();

            entityTypeBuilder
                .Property(nameof(Squad.State))
                .HasColumnType("tinyint")
                .HasColumnName(nameof(Squad.State))
                .IsRequired();

            entityTypeBuilder
                .Property(nameof(Squad.SquadOwnerId))
                .HasColumnName(nameof(Squad.SquadOwnerId))
                .IsRequired(false);

            entityTypeBuilder
                .HasMany(squad => squad.Users)
                .WithOne()
                .HasForeignKey(user => user.SquadId)
                .OnDelete(DeleteBehavior.SetNull);

            entityTypeBuilder
                .HasMany(squad => squad.Teams)
                .WithOne()
                .HasForeignKey(team => team.SquadId);
            
            entityTypeBuilder.HasData(
                new Squad(
                    Guid.Parse("1a0e19f9-8e92-41a1-9e92-09c587caef05"),
                    "Drużyna Oskara",
                    Guid.Parse("eab0a7ad-8542-4e1a-8dd3-a8391edbf5f4"),
                    State.Active),
                new Squad(
                    Guid.Parse("6251c1dc-58b9-43fa-bf01-098037d53bb6"), 
                    "Drużyna Szymka",
                    Guid.Parse("fa797f3e-b77a-4b92-a7e3-5aeba9aa4675"),
                    State.Active),
                new Squad(
                    Guid.Parse("c7d09645-cf24-4aca-93c1-96e8c97e4286"),
                    "Drużyna Olka",
                    Guid.Parse("321a719b-b778-485f-8432-11f0f038cbce"),
                    State.Active
                    )
                );
        }
    }
}
