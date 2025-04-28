using System.ComponentModel.DataAnnotations;

namespace Railway.Data.Models;

public class ShoppingCartItem
{
    public int ShoppingCartItemId { get; set; }

    public int UserId { get; set; }

    public User? User { get; set; }

    public int RouteId { get; set; }

    public Route? Route { get; set; }

    public int TicketTypeId { get; set; }

    public TicketType? TicketType { get; set; }

    public int? DepartureStationId { get; set; }

    public Station? DepartureStation { get; set; }

    [MaxLength(255)] public string DepartureStationName { get; set; } = "";

    public DateTime DepartureDateTime { get; set; }

    public int? ArrivalStationId { get; set; }

    public Station? ArrivalStation { get; set; }

    [MaxLength(255)] public string ArrivalStationName { get; set; } = "";

    public DateTime ArrivalDateTime { get; set; }

    [MaxLength(255)] public string? FirstName { get; set; }

    [MaxLength(255)] public string? LastName { get; set; }

    public decimal Price { get; set; }
}