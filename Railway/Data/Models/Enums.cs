namespace Railway.Data.Models;

public enum TicketStatus
{
    Unpaid,
    Planned,
    Active,
    Used,
    Cancelled
}

public enum UserRole
{
    User = 0,
    Admin
}