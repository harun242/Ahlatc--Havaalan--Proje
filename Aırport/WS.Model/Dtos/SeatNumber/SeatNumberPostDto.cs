using Infrastructure.Model;

namespace WS.Model.Dtos.SeatNumber
{
    public class SeatNumberPostDto : IDto
    {
        public string? BoardingCity { get; set; }
        public string? LandedCity { get; set; }
        public int? TicketNumber { get; set; }
    }
}
