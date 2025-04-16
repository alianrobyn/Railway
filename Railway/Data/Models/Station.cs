using System.ComponentModel.DataAnnotations;

namespace Railway.Data.Models;

public class Station
{
    public int StationId { get; set; }

    [MaxLength(255)] public string Name { get; set; } = null!;
}