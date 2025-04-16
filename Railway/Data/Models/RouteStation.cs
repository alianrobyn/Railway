namespace Railway.Data.Models;

public class RouteStation
{
    public int RouteStationId { get; set; }
    public Route Route { get; set; } = null!;
    public Station Station { get; set; } = null!;
    public TimeOnly ArrivalTime { get; set; }
    public TimeOnly DepartureTime { get; set; }
}