using System.ComponentModel.DataAnnotations;

namespace Railway.Data.Models
{
    public class TicketType
    {
        public int TicketTypeId { get; set; }

        [MaxLength(255)] public string? Name { get; set; }

        public decimal AdditionCost { get; set; }
    }
}