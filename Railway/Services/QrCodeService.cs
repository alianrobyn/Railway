using System.Text.Json;
using QRCoder;
using Railway.Data.Models;

namespace Railway.Services;

public class QrCodeService
{
    public byte[] GenerateQrCodeForTicket(Ticket ticket)
    {
        // Create a simplified ticket data object for the QR code
        var ticketData = new
        {
            Id = ticket.TicketId,
            Route = $"{ticket.Route?.StartStation.Name} → {ticket.Route?.EndStation.Name}",
            DepartureStation = ticket.DepartureStationName,
            DepartureTime = ticket.DepartureDateTime.ToString("dd.MM.yyyy HH:mm"),
            ArrivalStation = ticket.ArrivalStationName,
            ArrivalTime = ticket.ArrivalDateTime.ToString("dd.MM.yyyy HH:mm"),
            Passenger = $"{ticket.FirstName} {ticket.LastName}",
            TicketType = ticket.TicketType?.Name,
            Price = ticket.TicketPrice
        };

        // Serialize the ticket data to JSON
        var ticketJson = JsonSerializer.Serialize(ticketData);

        // Generate QR code
        using var qrGenerator = new QRCodeGenerator();
        var qrCodeData = qrGenerator.CreateQrCode(ticketJson, QRCodeGenerator.ECCLevel.Q);
        using var qrCode = new PngByteQRCode(qrCodeData);
        return qrCode.GetGraphic(20);
    }

    public string GetQrCodeAsBase64(Ticket ticket)
    {
        var qrCodeBytes = GenerateQrCodeForTicket(ticket);
        return Convert.ToBase64String(qrCodeBytes);
    }
}