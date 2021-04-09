using Client.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using Client.Services;
using System;

namespace Client.Controllers
{
    public class HomeController : Controller
    {
        private IShopService service { get; }

        public HomeController(IShopService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult CreatePet()
        {
            return View("~/Views/CreatePet.cshtml");
        }

        [HttpPost]
        public IActionResult CreatePet(String name, String type, int price)
        {
            try
            {
                PetDTO petDTO = new PetDTO
                {
                    Name = name,
                    Type = type,
                    Price = price
                };
                service.CreatePet(petDTO);

                return Content("Животное добавлено");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        public IActionResult GetPets()
        {
            try
            {
                var pets = service.GetFreePets().Result;
                return View("~/Views/GetPets.cshtml", pets);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        public IActionResult GetOrder(int? orderId)
        {
            try
            {
                OrderDTO order = service.GetOrders(orderId).Result;
                return View("~/Views/GetOrder.cshtml", order);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult MakeOrder()
        {
            return View("~/Views/MakeOrder.cshtml");
        }

        [HttpPost]
        public IActionResult MakeOrder(String CustomerName, String PhoneNumber, int Id, int Price)
        {
            try
            {
                OrderDTO orderDTO = new OrderDTO
                {
                    Sum = Price,
                    PhoneNumber = PhoneNumber,
                    CustomerName = CustomerName,
                    PetId = Id
                };
                service.MakeOrder(orderDTO);

                return Content("Животное куплено");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
    }
}
