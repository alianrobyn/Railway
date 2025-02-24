using Railway.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using System;
using Microsoft.Identity.Client;
using Route = Railway.Models.Route;

namespace Railway.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<TicketType> TicketTypes { get; set; }
        public DbSet<TrainType> TrainTypes { get; set; }
        public DbSet<RoutePrice> RoutePrices { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("DefaultConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<TicketType>().ToTable("TicketType");
            modelBuilder.Entity<TrainType>().ToTable("TrainType");
            modelBuilder.Entity<RoutePrice>().ToTable("RoutePrice");
            modelBuilder.Entity<Route>().ToTable("Route");
            modelBuilder.Entity<Ticket>().ToTable("Ticket");
        }
    }
}
