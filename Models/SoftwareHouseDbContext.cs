using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SoftwareHouseManagement.Models.Entities;

namespace SoftwareHouseManagement.Models
{
    public class SoftwareHouseDbContext : DbContext
    {
        public SoftwareHouseDbContext(DbContextOptions options): base(options) {}

        public DbSet<Worker> Workers { get; set; }
        public DbSet<Computer> Computers { get; set; }
        public DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
