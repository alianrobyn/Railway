using System.ComponentModel.DataAnnotations;
using System.Net.Sockets;

namespace Railway.Models
{
    public class RoutePrice
    {
        public int RoutePriceID { get; set; }

        public decimal Route_Price { get; set; }


        public ICollection<Route> Routes { get; set; }
    }
}
