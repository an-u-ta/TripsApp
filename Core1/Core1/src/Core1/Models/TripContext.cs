using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;

namespace Core1.Models
{
    public class TripContext : IdentityDbContext<AppUser>
    {
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Stop> Stops { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connString =
               Startup.Configuration["Data:DefaultConnection:TripsConnectionString"];
            optionsBuilder.UseSqlServer(connString);
            base.OnConfiguring(optionsBuilder);

        }
        public TripContext()
        {
            Database.EnsureCreated();
        }
    }
}
