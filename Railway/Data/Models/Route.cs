namespace Railway.Data.Models;

public class Route
{
    public int RouteId { get; set; }

    public int TrainTypeId { get; set; }

    public TrainType TrainType { get; set; } = null!;

    public int? StartStationId { get; set; }

    public Station StartStation { get; set; } = null!;

    public int? EndStationId { get; set; }

    public Station EndStation { get; set; } = null!;

    public DateTime DepartureDateTime { get; set; }

    public DateTime ArrivalDateTime { get; set; }

    public int AvailableSeats { get; set; }

    public DateTime FixationDateTime { get; set; }

    public decimal Price { get; set; }

    public ICollection<RouteStation> RouteStations { get; set; } = [];
}