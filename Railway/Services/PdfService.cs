using QuestPDF.Fluent;
using QuestPDF.Helpers;
using Railway.Data.Models;

namespace Railway.Services;

public class PdfService(QrCodeService qrCodeService)
{
    public byte[] GenerateTicketPdf(Ticket ticket)
    {
        var qrCodeBytes = qrCodeService.GenerateQrCodeForTicket(ticket);

        var document = Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(50);
                page.PageColor(Colors.White);
                page.DefaultTextStyle(x => x.FontSize(12).Fallback(y => y.FontFamily("Arial")));

                page.Header().Column(column =>
                {
                    column.Item().AlignCenter().Text("ЗАЛІЗНИЧНИЙ КВИТОК")
                        .FontSize(20).Bold().FontColor(Colors.Blue.Medium);

                    column.Item().AlignCenter().Text($"Квиток № {ticket.TicketId}")
                        .FontSize(14);

                    column.Item().AlignCenter().PaddingVertical(10);
                });

                page.Content().Column(column =>
                {
                    // Route information
                    column.Item().Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.RelativeColumn();
                            columns.RelativeColumn(2);
                        });

                        table.Cell().Text("Маршрут:").Bold();
                        table.Cell().Text($"{ticket.Route?.StartStation.Name} → {ticket.Route?.EndStation.Name}");

                        table.Cell().Text("Відправлення:").Bold();
                        table.Cell()
                            .Text($"{ticket.DepartureStationName}, {ticket.DepartureDateTime:dd.MM.yyyy HH:mm}");

                        table.Cell().Text("Прибуття:").Bold();
                        table.Cell().Text($"{ticket.ArrivalStationName}, {ticket.ArrivalDateTime:dd.MM.yyyy HH:mm}");

                        table.Cell().Text("Пасажир:").Bold();
                        table.Cell().Text($"{ticket.FirstName} {ticket.LastName}");

                        table.Cell().Text("Тип квитка:").Bold();
                        table.Cell().Text(ticket.TicketType?.Name);

                        table.Cell().Text("Ціна:").Bold();
                        table.Cell().Text($"{ticket.TicketPrice:C2}");

                        table.Cell().Text("Статус:").Bold();
                        table.Cell().Text(GetStatusName(ticket.TicketStatus));
                    });

                    // QR code
                    column.Item().MaxHeight(200).AlignCenter().PaddingVertical(20).Image(qrCodeBytes).FitArea();

                    column.Item().AlignCenter().Text("Відскануйте QR-код для перевірки квитка")
                        .FontSize(10).Italic();
                });

                page.Footer().AlignCenter().Text(x =>
                {
                    x.Span("Згенеровано: ");
                    x.Span($"{DateTime.Now:dd.MM.yyyy HH:mm}").Bold();
                });
            });
        });

        using (var stream = new MemoryStream())
        {
            document.GeneratePdf(stream);
            return stream.ToArray();
        }
    }

    private string GetStatusName(TicketStatus status)
    {
        return status switch
        {
            TicketStatus.Unpaid => "Не сплачено",
            TicketStatus.Planned => "Заплановано",
            TicketStatus.Active => "Активний",
            TicketStatus.Used => "Використано",
            TicketStatus.Cancelled => "Скасовано",
            _ => "Невідомо"
        };
    }
}