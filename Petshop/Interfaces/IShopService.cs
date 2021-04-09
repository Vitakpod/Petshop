using Petshop.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petshop.BLL.Interfaces
{
    public interface IShopService
    {
        void MakeOrder(OrderDTO orderDto);
        PetDTO GetPet(int? id);
        IEnumerable<PetDTO> GetPets();
        public void CreatePet(PetDTO petDTO);
        public IEnumerable<PetDTO> GetFreePets();
        public OrderDTO GetOrders(int? OrderId);
        void Dispose();
    }

}
