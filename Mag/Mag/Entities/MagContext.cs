using Mag.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace Mag.Entities
{
    public class MagContext : DbContext
    {
        string _connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=MagDb;Trusted_Connection=True;";

        public DbSet<User> users { get; set; }
        public DbSet<Squad> squads { get; set; }                                                       
        public DbSet<Category> categories { get; set; }
        public DbSet<Quality> qualities { get; set; }       
        public DbSet<LoanHistory> loanHistories { get; set; }
        public DbSet<Item> items { get; set; }

        /*
        Users<->Squads -Jeden do Jeden  *

        Users<->LoanHistory jeden do wielu 

        Users<->Items- Jeden do wielu  * 

        Items<->Categories- Jeden do jeden  *

        Items<->Quality- Jeden do jeden  *  

        Items<->LoanHistory- Jeden do wielu 
        */

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

    }
}
