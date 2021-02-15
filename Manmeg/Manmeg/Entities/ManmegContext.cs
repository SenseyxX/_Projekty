using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Manmeg.Entities
{
        public class ManmegContext:DbContext
        {
            string _connectionString = "Server=O-GACKI-N;Database=ManmenDB;Trusted_Connection=True;";

                public DbSet<Item> Items { get; set; }
                public DbSet<User> Users { get; set; }
                public DbSet<Squad> Squads { get; set; }
                public DbSet<LoanHistory> LoanHistories { get; set; }
                public DbSet<Quality> Qualities { get; set; }
                public DbSet<Category> Categories { get; set; }



             protected override void OnModelCreating(ModelBuilder modelBuilder)
             {
                    

             }


             protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
             {
                        optionsBuilder.UseSqlServer(_connectionString);
             }

        }
}
