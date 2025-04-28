using Microsoft.EntityFrameworkCore;
using Railway.Data;
using Railway.Data.Models;

namespace Railway.Services;

public class CartService(AppDbContext dbContext, IHttpContextAccessor httpContextAccessor)
{
    public async Task<List<ShoppingCartItem>> GetCartItemsAsync(int userId)
    {
        return await dbContext.ShoppingCartItems
            .Include(c => c.Route)
            .Include(c => c.DepartureStation)
            .Include(c => c.ArrivalStation)
            .Include(c => c.TicketType)
            .Where(c => c.UserId == userId)
            .ToListAsync();
    }

    public async Task<bool> AddToCartAsync(ShoppingCartItem cartItem)
    {
        try
        {
            dbContext.ShoppingCartItems.Add(cartItem);
            await dbContext.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> RemoveFromCartAsync(int cartItemId, int userId)
    {
        var cartItem = await dbContext.ShoppingCartItems
            .FirstOrDefaultAsync(c => c.ShoppingCartItemId == cartItemId && c.UserId == userId);

        if (cartItem == null)
            return false;

        dbContext.ShoppingCartItems.Remove(cartItem);
        await dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> ClearCartAsync(int userId)
    {
        var cartItems = await dbContext.ShoppingCartItems
            .Where(c => c.UserId == userId)
            .ToListAsync();

        if (!cartItems.Any())
            return false;

        dbContext.ShoppingCartItems.RemoveRange(cartItems);
        await dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<List<Ticket>> CheckoutAsync(int userId)
    {
        var cartItems = await GetCartItemsAsync(userId);
        var tickets = new List<Ticket>();

        foreach (var item in cartItems)
        {
            var ticket = new Ticket
            {
                UserId = userId,
                RouteId = item.RouteId,
                TicketTypeId = item.TicketTypeId,
                DepartureStationId = item.DepartureStationId,
                DepartureStationName = item.DepartureStationName,
                DepartureDateTime = item.DepartureDateTime,
                ArrivalStationId = item.ArrivalStationId,
                ArrivalStationName = item.ArrivalStationName,
                ArrivalDateTime = item.ArrivalDateTime,
                FirstName = item.FirstName,
                LastName = item.LastName,
                TicketPrice = item.Price,
                TicketStatus = TicketStatus.Unpaid
            };

            dbContext.Tickets.Add(ticket);
            tickets.Add(ticket);
        }

        await dbContext.SaveChangesAsync();
        await ClearCartAsync(userId);

        return tickets;
    }

    public async Task<bool> ProcessPaymentAsync(int userId)
    {
        try
        {
            // Get all unpaid tickets for the user
            var unpaidTickets = await dbContext.Tickets
                .Where(t => t.UserId == userId && t.TicketStatus == TicketStatus.Unpaid)
                .Include(t => t.Route)
                .ToListAsync();

            if (!unpaidTickets.Any())
                return false;

            // Group tickets by route to update available seats
            var ticketsByRoute = unpaidTickets.GroupBy(t => t.RouteId);

            // Update each route's available seats
            foreach (var routeGroup in ticketsByRoute)
            {
                var route = await dbContext.Routes.FindAsync(routeGroup.Key);
                if (route != null)
                {
                    route.AvailableSeats -= routeGroup.Count();
                    // Ensure we don't go below zero
                    if (route.AvailableSeats < 0)
                        route.AvailableSeats = 0;
                }
            }

            // Update all tickets to Planned status
            foreach (var ticket in unpaidTickets) ticket.TicketStatus = TicketStatus.Planned;

            await dbContext.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<int> GetCurrentUserIdAsync()
    {
        if (httpContextAccessor.HttpContext?.User?.Identity?.IsAuthenticated != true) return -1;

        var username = httpContextAccessor.HttpContext.User.Identity.Name;
        var user = await dbContext.Users.FirstOrDefaultAsync(u => u.UserName == username);
        return user?.Id ?? -1;
    }

    public async Task<User?> GetCurrentUserAsync()
    {
        if (httpContextAccessor.HttpContext?.User?.Identity?.IsAuthenticated != true) return null;

        var username = httpContextAccessor.HttpContext.User.Identity.Name;
        var user = await dbContext.Users.FirstOrDefaultAsync(u => u.UserName == username);
        return user;
    }
}