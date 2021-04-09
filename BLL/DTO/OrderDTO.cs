using Petshop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petshop.BLL.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public decimal Sum { get; set; }
        public string PhoneNumber { get; set; }
        public string CustomerName { get; set; }
        public int PetId { get; set; }
        public Pet Pet { get; set; }
        public DateTime? Date { get; set; }
    }

}
