using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Petshop.BLL.Interfaces;
using Petshop.BLL.DTO;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShopController : ControllerBase
    {
        IShopService service;

        public ShopController(IShopService service)
        {
            this.service = service;
        }

        [HttpPut]
        [Route("/Shop/CreatePet")]
        public void CreatePet(PetDTO petDTO)
        {
            service.CreatePet(petDTO);
        }

        [HttpGet]
        [Route("/Shop/GetPets")]
        public IEnumerable<PetDTO> GetPets()
        {
            IEnumerable<PetDTO> pets = service.GetPets();
            return pets;
        }

        [HttpGet]
        [Route("/Shop/GetOrders")]
        public OrderDTO GetOrder(int? orderId)
        {
            OrderDTO order = service.GetOrders(orderId);
            return order;
        }

        [HttpGet]
        [Route("/Shop/GetPet")]
        public PetDTO GetPet(int? id)
        {
            PetDTO pet = service.GetPet(id);
            return pet;
        }

        [HttpGet]
        [Route("/Shop/GetFreePets")]
        public IEnumerable<PetDTO> GetFreePets()
        {
            IEnumerable<PetDTO> pets = service.GetFreePets();
            return pets;
        }

        [HttpPut]
        [Route("/Shop/MakeOrder")]
        public void MakeOrder(OrderDTO orderDTO)
        {
            service.MakeOrder(orderDTO);
        }

    }
}
