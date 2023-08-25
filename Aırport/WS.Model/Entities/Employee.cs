using Infrastructure.Model;
using System.ComponentModel.DataAnnotations;

namespace WS.Model.Entities
{
    public class Employee : IEntity
    {
        [Key]
        public int EmployeeID { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public bool? IsActive { get; set; } = true;

    }
}
