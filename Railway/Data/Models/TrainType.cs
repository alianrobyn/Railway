using System.ComponentModel.DataAnnotations;

namespace Railway.Data.Models
{
    public class TrainType
    {
        public int TrainTypeId { get; set; }

        [MaxLength(100)] public string? Name { get; set; }

        public decimal AdditionCost { get; set; }
    }
}