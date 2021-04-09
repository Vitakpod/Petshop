using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Client.Models;

namespace Client.Services
{
    public interface IShopService
    {
        public void CreatePet(PetDTO petDTO);
        public Task<IEnumerable<PetDTO>> GetFreePets();
        public Task<IEnumerable<PetDTO>> GetPets();
        public Task<PetDTO> GetPet(int? id);
        public Task<OrderDTO> GetOrders(int? OrderId);
        public void MakeOrder(OrderDTO orderDto);
    }
}
