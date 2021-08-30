using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using Warehouse.Persistence.Entities;
using Warehouse.Persistence.Entities.User.Enums;
using Half = Warehouse.Persistence.Entities.User.Enums.Half;

namespace Warehouse.Persistence.Context.EntitiesConfiguration
{
	 internal sealed class DueTypeConfiguration : IEntityTypeConfiguration<Due>
	 {
		  private const string TableName = "Dues";
		  public void Configure(EntityTypeBuilder<Due>entityTypeBuilder)
		  {
			   entityTypeBuilder
				  .ToTable(TableName, WarehouseContext.DefaultSchemaName)
				  .HasKey(dues => dues.Id);

			   entityTypeBuilder
				    .Property<Guid>(nameof(Due.UserId))
				    .HasColumnName(nameof(Due.UserId))
				    .IsRequired();

			   entityTypeBuilder
				  .Property<Half>(nameof(Due.Half))
				  .HasColumnType("tinyint")
				  .HasColumnName(nameof(Due.Half))
				  .IsRequired();

			   entityTypeBuilder
        			  .Property<int>(nameof(Due.Amount))
				  .HasColumnType("int")
				  .HasColumnName(nameof(Due.Amount))
				  .IsRequired();

			   entityTypeBuilder
				  .Property<Status>(nameof(Due.Status))
				  .HasColumnType("tinyint")
				  .HasColumnName(nameof(Due.Status))
				  .IsRequired();	 
		  }
	 }
}
