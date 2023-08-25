using Infrastructure.Model;
using System.ComponentModel.DataAnnotations;

namespace WS.Model.Entities
{
    public class Ticket : IEntity
    {
        [Key]
        public int  TıcketID { get; set; }
        public int? PassengerID { get; set; }
        public int? SeatNumber { get; set; }
        public string? PassengerName { get; set; }
        public string? PassengerSurname { get; set; }
        public decimal? Fee { get; set; }
        public string? BoardingCity { get; set; }
        public string? LandedCity { get; set; }
        public bool? IsActive { get; set; } = true;

    }
}
