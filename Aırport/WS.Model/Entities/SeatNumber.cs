using Infrastructure.Model;
using System.ComponentModel.DataAnnotations;

namespace WS.Model.Entities
{
    public class SeatNumber : IEntity
    {
        [Key]
        public int ExpeditionID { get; set; }
        public string? BoardingCity { get; set; }
        public string? LandedCity { get; set; }
        public int? TicketNumber { get; set; }
        public bool? IsActive { get; set; } = true;
    }

}
