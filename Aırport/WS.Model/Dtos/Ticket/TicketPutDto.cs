using Infrastructure.Model;

namespace WS.Model.Dtos.Ticket
{
    public class TicketPutDto : IDto
    {
        public int TıcketID { get; set; }
        public int? PassengerID { get; set; }
        public int? SeatNumber { get; set; }
        public string? PassengerName { get; set; }
        public string? PassengerSurname { get; set; }
        public decimal? Fee { get; set; }
        public string? BoardingCity { get; set; }
        public string? LandedCity { get; set; }
    }
}
