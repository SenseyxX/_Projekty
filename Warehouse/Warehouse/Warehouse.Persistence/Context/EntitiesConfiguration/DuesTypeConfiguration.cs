using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using Warehouse.Persistence.Entities;
using Warehouse.Persistence.Entities.User.Enums;
using Half = Warehouse.Persistence.Entities.User.Enums.Half;

namespace Warehouse.Persistence.Context.EntitiesConfiguration
{
	 internal sealed class DuesTypeConfiguration : IEntityTypeConfiguration<Dues>
	 {
		  private const string TableName = "Dues";
		  public void Configure(EntityTypeBuilder<Dues>entityTypeBuilder)
		  {
			   entityTypeBuilder
				  .ToTable(TableName, WarehouseContext.DefaultSchemaName)
				  .HasKey(dues => dues.Id);

			   entityTypeBuilder
				    .Property<Guid>(nameof(Dues.UserId))
				    .HasColumnName(nameof(Dues.UserId))
				    .IsRequired();

			   entityTypeBuilder
				  .Property<Half>(nameof(Dues.Half))
				  .HasColumnType("tinyint")
				  .HasColumnName(nameof(Dues.Half))
				  .IsRequired();

			   entityTypeBuilder
        			  .Property<int>(nameof(Dues.Amount))
				  .HasColumnType("int")
				  .HasColumnName(nameof(Dues.Amount))
				  .IsRequired();

			   entityTypeBuilder
				  .Property<Status>(nameof(Dues.Status))
				  .HasColumnType("tinyint")
				  .HasColumnName(nameof(Dues.Status))
				  .IsRequired();	 
		  }
	 }
}
