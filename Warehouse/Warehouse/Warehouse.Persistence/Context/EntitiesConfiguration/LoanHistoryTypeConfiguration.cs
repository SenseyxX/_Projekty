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
    class LoanHistoryTypeConfiguration:IEntityTypeConfiguration<LoanHistory>
    {
        private const string TableName = "LoanHistory";

        public void Configure(EntityTypeBuilder<LoanHistory> entityTypeBuilder)
        {
            entityTypeBuilder
                .ToTable(TableName, WarehouseContext.DefaultSchemaName)
                .HasKey(loanhistory => loanhistory.Id);

            entityTypeBuilder
                .Property<DateTime>(nameof(LoanHistory.LoanDate))
                .HasColumnName(nameof(LoanHistory.LoanDate));                
        }
    }
}
