using Petshop.Domain.Models;
using System.Collections.Generic;


namespace Petshop.BLL.DTO
{
    public class PetDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
        public virtual ICollection<OrderDTO> Orders { get; set; }
    }

}
