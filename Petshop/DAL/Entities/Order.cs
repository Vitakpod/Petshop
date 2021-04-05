using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petshop.DAL.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public decimal Sum { get; set; }
        public string PhoneNumber { get; set; }
        public string CustomerName { get; set; }

        public int PetId { get; set; }
        public virtual Pet Pet { get; set; }

        public DateTime Date { get; set; }
    }

}
