using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Warehouse.Domain.Category.Enumeration;
using Warehouse.Domain.Squad.Entities;
using Warehouse.Infrastructure.Persistence.Context;

namespace Warehouse.Infrastructure.Persistence.EntitiesConfiguration
{
	 internal sealed class TeamTypeConfiguration : IEntityTypeConfiguration<Team>
	 {
		  private const string TableName = "Teams";

		  public void Configure(EntityTypeBuilder<Team> entityTypeBuilder)
		  {
			   entityTypeBuilder
				    .ToTable(TableName, WarehouseContext.DefaultSchemaName)
				    .HasKey(team => team.Id);

			   entityTypeBuilder
				    .Property(nameof(Team.Name))
				    .HasMaxLength(30)
				    .HasColumnName(nameof(Team.Name))
				    .IsRequired();

			   entityTypeBuilder
				   .Property(nameof(Team.TeamOwnerId))
				   .HasColumnName(nameof(Team.TeamOwnerId));

			   entityTypeBuilder
					.Property(nameof(Team.Description))
					.HasMaxLength(1000)
					.HasColumnName(nameof(Team.Description));

			   entityTypeBuilder
				    .Property(nameof(Team.Points))
				    .HasColumnType("tinyint")
				    .HasColumnName(nameof(Team.Points));

               entityTypeBuilder
                   .HasMany(team => team.Users)
                   .WithOne()
                   .HasForeignKey(user => user.TeamId);

			   entityTypeBuilder.HasQueryFilter(team => team.State != State.Deleted);
			   
			   entityTypeBuilder.HasData(
				   new Team(
					   Guid.Parse("296f60db-9f13-48f3-853f-343de5ebdd20"),
					   "Zastęp Oskara",
					   Guid.Parse("eab0a7ad-8542-4e1a-8dd3-a8391edbf5f4"),
					   Guid.Parse("1a0e19f9-8e92-41a1-9e92-09c587caef05"),
					   "Opis zastępu Oskara",
					   0,
					   State.Active
				   ),   
				   new Team(
					   Guid.Parse("f7921a66-83b4-451d-8556-893882233118"),
					   "Zastęp Szymka",
					   Guid.Parse("fa797f3e-b77a-4b92-a7e3-5aeba9aa4675"),
					   Guid.Parse("6251c1dc-58b9-43fa-bf01-098037d53bb6"),
					   "Opis zastępu Szymka",
					   0,
					   State.Active
				   ),   
				   new Team(
					   Guid.Parse("d1401039-21d8-4a83-97e1-67dd2201e4a1"),
					   "Zastęp Olka",
					   Guid.Parse("321a719b-b778-485f-8432-11f0f038cbce"), 
					   Guid.Parse("c7d09645-cf24-4aca-93c1-96e8c97e4286"),
					   "Opis zastępu Olka",
					   0,
					   State.Active
				   )   
			   );
		  }
	 }
}
