namespace AırportMvcUI.Areas.AdminPanel.Models.Dtos.Ticket
{
    public class NewTicketDto
    {
        public int PassengerID { get; set; }
        public int SeatNumber { get; set; }
        public string PassengerName { get; set; }
        public string PassengerSurname { get; set; }
        public decimal Fee { get; set; }
        public string BoardingCity { get; set; }
        public string LandedCity { get; set; }
    }
}
