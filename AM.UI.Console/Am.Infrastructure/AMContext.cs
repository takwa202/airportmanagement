﻿using Am.Infrastructure.Configuration;
using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Am.Infrastructure
{
    public class AMContext : DbContext
    {

        public DbSet<Flight> Flights { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<plane> planes { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Traveller> Travellers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
        Initial Catalog=OussamaLachihebDB;Integrated Security=true;MultipleActiveResultSets=true");
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLazyLoadingProxies();

        }
        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfiguration(new PlaneConfiguration());
            modelBuilder
                .ApplyConfiguration(new FlightConfiguration());
            modelBuilder
                .ApplyConfiguration(new PassengerConfiguration());
            modelBuilder.ApplyConfiguration(new TicketConfiguration());
            modelBuilder
                .Entity<Staff>()
                .ToTable("staff");
            modelBuilder
                .Entity<Traveller>()
                .ToTable("traveller");
        }
        protected override void ConfigureConventions(ModelConfigurationBuilder modelConfigurationBuilder)
        {
            modelConfigurationBuilder.
                Properties<DateTime>().
                HaveColumnType("date");
        }
    }
}
