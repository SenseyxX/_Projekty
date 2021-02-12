using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Manmeg.Entities
{
        public class ManmegContext:DbContext
        {
            string _connectionString = "Server=O-GACKI-N;Database=MeetupDb;Trusted_Connection=True;";

                public DbSet<Item> Items { get; set; }

        }
}
