using Infrastructure.Model;

namespace WS.Model.Dtos.Flight
{
    public class FlightPostDto : IDto
    {
        public string? DepartureCity { get; set; }
        public string? LandingCity { get; set; }
    }
}
