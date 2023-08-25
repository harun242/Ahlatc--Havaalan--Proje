using Infrastructure.Model;
using System.ComponentModel.DataAnnotations;

namespace WS.Model.Entities
{
    public class Flight : IEntity
    {
        [Key]
        public int RouteID { get; set; }
        public string? DepartureCity { get; set; }
        public string? LandingCity { get; set; }
        public bool? IsActive { get; set; } = true;
    }
}
