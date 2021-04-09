using System;
using Petshop.Domain.Interfaces;

namespace Petshop.Domain.Models
{
    public class Order
    {
        public int Id { get; set; }
        public decimal Sum { get; set; }
        public string PhoneNumber { get; set; }
        public string CustomerName { get; set; }

        public int PetId { get; set; }
        public Pet Pet { get; set; }

        public DateTime Date { get; set; }
    }
}
