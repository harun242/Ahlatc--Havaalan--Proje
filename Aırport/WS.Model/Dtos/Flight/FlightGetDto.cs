using Infrastructure.Model;

namespace WS.Model.Dtos.Flight
{
    public class FlightGetDto : IDto
    {
        public int RouteID { get; set; }
        public string? DepartureCity { get; set; }
        public string? LandingCity { get; set; }
    }
}
