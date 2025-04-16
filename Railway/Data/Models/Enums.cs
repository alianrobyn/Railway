namespace Railway.Data.Models;

public enum TicketStatus
{
    Planned,
    Active,
    Used,
    Cancelled
}

public enum UserRole
{
    User = 0,
    Admin,
}