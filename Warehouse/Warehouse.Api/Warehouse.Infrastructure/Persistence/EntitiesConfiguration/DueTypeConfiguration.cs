using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Warehouse.Domain.User.Entities;
using Warehouse.Infrastructure.Persistence.Context;

namespace Warehouse.Infrastructure.Persistence.EntitiesConfiguration
{
	 internal sealed class DueTypeConfiguration : IEntityTypeConfiguration<Due>
	 {
		  private const string TableName = "Dues";

		  public void Configure(EntityTypeBuilder<Due> entityTypeBuilder)
		  {
			   entityTypeBuilder
				  .ToTable(TableName, WarehouseContext.DefaultSchemaName)
				  .HasKey(dues => dues.Id);

			   entityTypeBuilder
				    .Property(nameof(Due.UserId))
				    .HasColumnName(nameof(Due.UserId))
				    .IsRequired();

			   entityTypeBuilder
				  .Property(nameof(Due.Half))
				  .HasColumnType("tinyint")
				  .HasColumnName(nameof(Due.Half))
				  .IsRequired();

			   entityTypeBuilder
                   .Property(nameof(Due.Amount))
				  .HasColumnType("int")
				  .HasColumnName(nameof(Due.Amount))
				  .IsRequired();

			   entityTypeBuilder
				  .Property(nameof(Due.DueStatus))
				  .HasColumnType("tinyint")
				  .HasColumnName(nameof(Due.DueStatus))
				  .IsRequired();
		  }
	 }
}
