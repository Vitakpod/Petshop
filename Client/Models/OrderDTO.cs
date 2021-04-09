using System;


namespace Client.Models
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public decimal Sum { get; set; }
        public string PhoneNumber { get; set; }
        public string CustomerName { get; set; }
        public int PetId { get; set; }
        public DateTime? Date { get; set; }
    }
}
