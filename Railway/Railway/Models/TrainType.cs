using System.ComponentModel.DataAnnotations;
using System.Net.Sockets;

namespace Railway.Models
{
    public class TrainType
    {
        public int TrainTypeID { get; set; }

        public string Train_Type { get; set; }

        public decimal TrainTypePrice { get; set; }


        public ICollection<Route> Routes { get; set; }
    }
}
