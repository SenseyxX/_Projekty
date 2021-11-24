﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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
                .Property(nameof(Squad.CategoryState))
                .HasColumnType("tinyint")
                .HasColumnName(nameof(Squad.CategoryState))
                .IsRequired();

            entityTypeBuilder
                .HasMany(squad => squad.Users)
                .WithOne()
                .HasForeignKey(user => user.SquadId);
        }
    }
}