using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Warehouse.Application.Services;
using Warehouse.Application.Settings;
using Warehouse.Domain.Category.Enumeration;
using Warehouse.Domain.Squad.Entities;
using Warehouse.Domain.User.Entities;
using Warehouse.Domain.User.Enumeration;
using Warehouse.Infrastructure.Services;

namespace Warehouse.Infrastructure.Persistence.EntitiesConfiguration
{
    public static class DataSeeder
    {
        public static ModelBuilder SeedInitialData(this ModelBuilder modelBuilder, IEncryptionService encryptionService)
        {
            var users = new object[]
            {
                new
                {
                    Id = Guid.Parse("eab0a7ad-8542-4e1a-8dd3-a8391edbf5f4"),
                    Name = "Oskar",
                    LastName = "Gacki",
                    PasswordHash = encryptionService.EncodePassword("1234"),
                    Email = "ogacki",
                    PhoneNumber = "888888888",
                    PermissionLevel = PermissionLevel.Admin,
                    State = State.Active,
                    SquadId = Guid.Parse("1a0e19f9-8e92-41a1-9e92-09c587caef05"),
                    TeamId = Guid.Parse("296f60db-9f13-48f3-853f-343de5ebdd20")
                },
                new {
                    Id = Guid.Parse("fa797f3e-b77a-4b92-a7e3-5aeba9aa4675"), 
                    Name = "Szymon",
                    LastName = "Katryniok",
                    PasswordHash = encryptionService.EncodePassword("1234"),
                    Email = "skatryniok",
                    PhoneNumber = "999999999",
                    PermissionLevel = PermissionLevel.Admin,
                    State = State.Active,
                    SquadId = Guid.Parse("6251c1dc-58b9-43fa-bf01-098037d53bb6"), 
                    TeamId = Guid.Parse("f7921a66-83b4-451d-8556-893882233118")
                    },
                new {
                    Id = Guid.Parse("321a719b-b778-485f-8432-11f0f038cbce"), 
                    Name = "Aleksander",
                    LastName = "Kijowski",
                    PasswordHash = encryptionService.EncodePassword("1234"),
                    Email = "akijowski",
                    PhoneNumber =  "777777777",
                    PermissionLevel = PermissionLevel.Admin,
                    State = State.Active,
                    SquadId = Guid.Parse("c7d09645-cf24-4aca-93c1-96e8c97e4286"), 
                    TeamId = Guid.Parse("d1401039-21d8-4a83-97e1-67dd2201e4a1")
                    },
                new {
                    Id = Guid.Parse("071c18c6-93e1-40ef-ae43-bdb3c8f2aab6"), 
                    Name = "Wojtek",
                    LastName ="Patoń",
                    PasswordHash = encryptionService.EncodePassword("1234"),
                    Email = "akijowski",
                    PhoneNumber = "666666666",
                    PermissionLevel = PermissionLevel.Admin,
                    State = State.Active,
                    SquadId = Guid.Parse("1a0e19f9-8e92-41a1-9e92-09c587caef05"), 
                    TeamId = Guid.Parse("296f60db-9f13-48f3-853f-343de5ebdd20")
                    }
            };

            var teams = new object[]
            {
                new 
                {
                    Id = Guid.Parse("296f60db-9f13-48f3-853f-343de5ebdd20"),
                    Name ="Zastęp Oskara",
                    TeamOwnerId = Guid.Parse("eab0a7ad-8542-4e1a-8dd3-a8391edbf5f4"),
                    SquadId = Guid.Parse("1a0e19f9-8e92-41a1-9e92-09c587caef05"),
                    Description = "Opis zastępu Oskara",
                    Points = 1,
                    State = State.Active
                },   
                new 
                {
                    Id = Guid.Parse("f7921a66-83b4-451d-8556-893882233118"),
                    Name = "Zastęp Szymka",
                    TeamOwnerId = Guid.Parse("fa797f3e-b77a-4b92-a7e3-5aeba9aa4675"),
                    SquadId = Guid.Parse("6251c1dc-58b9-43fa-bf01-098037d53bb6"),
                    Description = "Opis zastępu Szymka",
                    Points = 1,
                    State = State.Active
                },   
                new 
                {
                    Id = Guid.Parse("d1401039-21d8-4a83-97e1-67dd2201e4a1"),
                    Name = "Zastęp Olka",
                    TeamOwnerId = Guid.Parse("321a719b-b778-485f-8432-11f0f038cbce"), 
                    SquadId = Guid.Parse("c7d09645-cf24-4aca-93c1-96e8c97e4286"),
                    Description = "Opis zastępu Olka",
                    Points =  1,
                    State = State.Active
                }  
            };

            var squads = new object[]
            {
                new {
                    Id = Guid.Parse("1a0e19f9-8e92-41a1-9e92-09c587caef05"),
                    Name = "Drużyna Oskara",
                    SquadOwnerId = Guid.Parse("eab0a7ad-8542-4e1a-8dd3-a8391edbf5f4"),
                    State = State.Active
                },
                new {
                    Id = Guid.Parse("6251c1dc-58b9-43fa-bf01-098037d53bb6"), 
                    Name = "Drużyna Szymka",
                    SquadOwnerId = Guid.Parse("fa797f3e-b77a-4b92-a7e3-5aeba9aa4675"),
                    State = State.Active
                    },
                new {
                    Id = Guid.Parse("c7d09645-cf24-4aca-93c1-96e8c97e4286"),
                    Name = "Drużyna Olka",
                    SquadOwnerId = Guid.Parse("321a719b-b778-485f-8432-11f0f038cbce"),
                    State = State.Active
                }
            };

            modelBuilder.Entity<User>()
                .HasData(users);

            modelBuilder.Entity<Team>()
                .HasData(teams);

            modelBuilder.Entity<Squad>()
                .HasData(squads);

            return modelBuilder;
        }
    }
}