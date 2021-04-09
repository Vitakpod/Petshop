using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petshop.DAL.Entities
{
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }

}
