using Manmeg.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetupAPI.Entities
{
    public class ManmegContext : DbContext
    {

        string _connectionString = "Server=O-GACKI-N;Database=MeetupDb;Trusted_Connection=True;";


                public DbSet<Item> Items { get; set; }
                public DbSet<User> Users { get; set; }
                public DbSet<Squad> Squads { get; set; }
                public DbSet<LoanHistory> LoanHistories { get; set; }
                public DbSet<Quality> Qualities { get; set; }
                public DbSet<Category> Categories { get; set; }

                protected override void OnModelCreating(ModelBuilder modelBuilder)
                {
                        modelBuilder.Entity<User>()
                                     .HasOne(m => m.Squad)
                                     .WithOne(l => l.User)
                                     .HasForeignKey<Squad>(s => s.UserId);

                        modelBuilder.Entity<Item>()
                                    .HasOne(m => m.Category)
                                    .WithOne(l => l.Item)
                                    .HasForeignKey<Category>(s => s.ItemId);

                        modelBuilder.Entity<Item>()
                                    .HasOne(m => m.Quality)
                                    .WithOne(l => l.Item)
                                    .HasForeignKey<Category>(s => s.ItemId);

                }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

    }
}
