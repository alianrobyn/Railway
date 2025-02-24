using System.ComponentModel.DataAnnotations;
using System.Net.Sockets;

namespace Railway.Models
{
    public class TicketType
    {
        public int TicketTypeID { get; set; }

        public string Ticket_Type { get; set; }

        public decimal TicketTypePrice { get; set; }


        public ICollection<Ticket> Tickets { get; set; }
    }
}
