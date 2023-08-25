namespace AırportMvcUI.Areas.AdminPanel.Models.Dtos.Customer
{
    public class UpdateCustomerDto
    {
        public int CustomerID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}
