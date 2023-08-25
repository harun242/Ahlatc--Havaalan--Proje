using Infrastructure.Model;

namespace WS.Model.Dtos.Employee
{
    public class EmployeePostDto : IDto
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
    }
}
