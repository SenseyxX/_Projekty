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
        //readonly string _connectionString = "Server=O-GACKI-N;Database=MagDb;Trusted_Connection=True;";

        public DbSet<User> Users { get; set; }
        public DbSet<Squad> Squads { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Quality> Qualities { get; set; }
        public DbSet<LoanHistory> LoanHistories { get; set; }
        public DbSet<Item> Items { get; set; }

        /*
        Users<->Squads -Wiele do Jeden  *

        Users<->LoanHistory jeden do wielu 

        Users<->Items- Jeden do wielu  * 

        Items<->Categories- Jeden do jeden  *

        Items<->Quality- Wiele do jeden  *  

        Items<->LoanHistory- Jeden do wielu 
        */

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                        modelBuilder.Entity<User>()
                          .HasOne(x => x.Squad)
                          .WithMany(x => x.Users)
                          .HasForeignKey(x => x.SquadId);                     
                

                        modelBuilder.Entity<Item>()
                          .HasOne(x => x.User)
                          .WithMany(x => x.Items)
                          .HasForeignKey(x => x.OwnerId);

                        modelBuilder.Entity<Item>()
                          .HasOne(x => x.Quality)
                          .WithMany(x => x.Items)
                          .HasForeignKey(x => x.QualityId);

                        modelBuilder.Entity<Item>()
                          .HasOne(x => x.Category)
                          .WithMany(x => x.Items)
                          .HasForeignKey(x => x.CategoryId);
                        

                                







                        //modelBuilder.Entity<Item>()
                        //    .HasOne(x => x.ActualUser)
                        //    .WithMany(x => x.MyItems)
                        //    .HasForeignKey(x => x.ActualOwnerId);

                        //modelBuilder.Entity<Item>()
                        //    .HasOne(x => x.ActualUser)
                        //    .WithMany()
                        //    .OnDelete(DeleteBehavior.Restrict);

                        //modelBuilder.Entity<Item>()
                        //    .HasOne(x => x.User)
                        //    .WithMany()
                        //    .OnDelete(DeleteBehavior.Restrict);
                }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
