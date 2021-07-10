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
	 internal sealed class TeamTypeConfiguration : IEntityTypeConfiguration<Team>
	 {
		  private const string TableName = "Teams";

		  public void Configure(EntityTypeBuilder<Team> entityTypeBuilder)
		  {
			   entityTypeBuilder
				    .ToTable(TableName, WarehouseContext.DefaultSchemaName)
				    .HasKey(team => team.Id);

			   entityTypeBuilder
				    .Property<string>(nameof(Team.Name))
				    .HasMaxLength(30)
				    .HasColumnName(nameof(Team.Name))
				    .IsRequired();

			   entityTypeBuilder
				    .Property<Guid>(nameof(Team.TeamOwnerId))
				    .HasColumnType("tinyint")
				    .HasColumnName(nameof(Team.TeamOwnerId))
				    .IsRequired();
			   
			   entityTypeBuilder
					.Property<string>(nameof(Team.Description))
					.HasMaxLength(1000)
					.HasColumnName(nameof(Team.Description));

			   entityTypeBuilder
				    .Property<int>(nameof(Team.Points))
				    .HasColumnType("tinyint")
				    .HasColumnName(nameof(Team.Points));

			   entityTypeBuilder
				    .HasMany(team => team.Users)
				    .WithOne()
				    .HasForeignKey(user => user.TeamId);

			   entityTypeBuilder.HasQueryFilter(team => team.State != State.Deleted);
		  }
	 }
}
