using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Sockets;

namespace Railway.Models
{
    public class Ticket
    {
        public int TicketID { get; set; }

        public int UserID { get; set; }

        public int RouteID { get; set; }

        public int TicketTypeID { get; set; }

        public string TicketStatus { get; set; }

        public string DepartureStation { get; set; }

        public DateTime DepartureDateTime { get; set; }

        public string ArrivalStation { get; set; }

        public DateTime ArrivalDateTime { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Ticket_Type { get; set; }

        public decimal TicketPrice { get; set; }



        public User User { get; set; }
        public Route Route { get; set; }
        public TicketType TicketType { get; set; }
    }
}
