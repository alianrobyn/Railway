using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Railway.Data.Models;
using Route = Railway.Data.Models.Route;

namespace Railway.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options)
    : IdentityDbContext<User, IdentityRole<int>, int>(options)
{
    public DbSet<TicketType> TicketTypes { get; set; }
    public DbSet<TrainType> TrainTypes { get; set; }
    public DbSet<Route?> Routes { get; set; }
    public DbSet<Station> Stations { get; set; }
    public DbSet<RouteStation> RouteStations { get; set; }
    public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
}