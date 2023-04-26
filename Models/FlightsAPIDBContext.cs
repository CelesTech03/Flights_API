using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using FlightsAPI.Models;
using System.Collections.Generic;

namespace FlightsAPI.Models
{
    public class FlightsAPIDBContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public FlightsAPIDBContext(DbContextOptions<FlightsAPIDBContext> options, IConfiguration configuration)
            : base(options)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = Configuration.GetConnectionString("FlightsDataService");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
        public DbSet<Flight> Flights { get; set; } = null!;
        public DbSet<Passenger> Passengers { get; set; } = null!;
        public DbSet<Booking> Bookings { get; set; } = null!;
    }
}

