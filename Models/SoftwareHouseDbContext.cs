using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SoftwareHouseManagement.Models.Entities;

namespace SoftwareHouseManagement.Models
{
    public class SoftwareHouseDbContext : IdentityDbContext<Worker>
    {
        public SoftwareHouseDbContext(DbContextOptions options): base(options) {}

        public DbSet<Worker> Workers { get; set; }
        public DbSet<Computer> Computers { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Responsibilities> Responsibilities { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Entities.Task> Tasks { get; set; }
        public DbSet<HoursWorked> HoursWorked { get; set; }
        public DbSet<Access> Accesses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
}
}
