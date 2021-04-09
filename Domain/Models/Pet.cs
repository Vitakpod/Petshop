using System.Collections.Generic;
using Petshop.Domain.Interfaces;

namespace Petshop.Domain.Models
{   
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
