using System.ComponentModel.DataAnnotations;
using System.Net.Sockets;

namespace Railway.Models
{
    public class Route
    {
        public int RouteID { get; set; }
        public int RoutePriceID { get; set; }


        public int TrainTypeID { get; set; }


        public string DepartureStation { get; set; }

        public string ArrivalStation { get; set; }

        public DateTime DepartureDateTime { get; set; }

        public DateTime ArrivalDateTime { get; set; }

        public string Train_Type { get; set; }


        public int AvailableSeats { get; set; }

        public DateTime FixationDateTime { get; set; }

        public decimal Price { get; set; }



        public ICollection<Ticket> Tickets { get; set; }
        public TrainType TrainType { get; set; }
        public RoutePrice RoutePrice { get; set; }
    }
}
