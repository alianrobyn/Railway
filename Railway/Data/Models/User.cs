using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Railway.Data.Models;

public class User : IdentityUser<int>
{
    [MaxLength(255)] public string? FirstName { get; set; }

    [MaxLength(255)] public string? LastName { get; set; }

    public ICollection<Ticket>? Tickets { get; set; } = [];

    public UserRole Role { get; set; }
}