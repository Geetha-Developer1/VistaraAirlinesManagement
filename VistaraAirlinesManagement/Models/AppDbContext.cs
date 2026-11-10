using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace VistaraAirlinesManagement.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext():base("getconn")
        {

        }
        public DbSet<EmployeeLogin> EmployeeLogin { get; set; }

        public DbSet<ManagerLogin> ManagerLogin { get; set; } 
        public DbSet<Flights> Flights { get; set; }
        public DbSet<FlightStatus> FlightsStatus { get; set; }
        public DbSet<Bookings> Bookings { get; set; }
        public DbSet<PassengerDetails> PassengerDetails { get; set; }
        public DbSet<Cancels> cancels { get; set; }
    }
}