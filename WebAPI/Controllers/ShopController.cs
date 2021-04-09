using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Petshop.BLL.Interfaces;
using Petshop.BLL.DTO;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LibController : ControllerBase
    {
        IShopService service;

        public LibController(IShopService service)
        {
            this.service = service;
        }

        [HttpPut]
        [Route("/ShopController/CreatePet")]
        public void CreateBook(PetDTO petDTO)
        {
            service.CreatePet(petDTO);
        }

        [HttpGet]
        [Route("/ShopController/GetPets")]
        public IEnumerable<PetDTO> GetPets()
        {
            IEnumerable<PetDTO> pets = service.GetPets();
            return pets;
        }

        [HttpGet]
        [Route("/ShopController/GetOrders")]
        public OrderDTO GetOrder(int? orderId)
        {
            OrderDTO order = service.GetOrders(orderId);
            return order;
        }

        [HttpGet]
        [Route("/ShopController/GetPet")]
        public PetDTO GetPet(int? id)
        {
            PetDTO pet = service.GetPet(id);
            return pet;
        }

        [HttpGet]
        [Route("/ShopController/GetFreePets")]
        public IEnumerable<PetDTO> GetFreePets()
        {
            IEnumerable<PetDTO> pets = service.GetFreePets();
            return pets;
        }

        [HttpPut]
        [Route("/ShopController/MakeOrder")]
        public void MakeOrder(OrderDTO orderDTO)
        {
            service.MakeOrder(orderDTO);
        }

    }
}
