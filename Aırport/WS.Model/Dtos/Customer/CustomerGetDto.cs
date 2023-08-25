using Infrastructure.Model;

namespace WS.Model.Dtos.Customer
{
    public class CustomerGetDto : IDto
    {
        public int CustomerID { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
    }
}
