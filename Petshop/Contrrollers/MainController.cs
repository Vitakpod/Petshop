using Microsoft.AspNetCore.Mvc;
using Petshop.BLL.Interfaces;
using Petshop.BLL.DTO;
using System.Collections.Generic;
using System;

namespace Petshop.Contrrollers
{
    public class MainController : Controller
    {
        IShopService shopService;
        public MainController(IShopService serv)
        {
            this.shopService = serv;
        }
        [HttpGet]
        public ActionResult Index()
        {
            return View("~/Pages/CreatePet.cshtml");
        }
        protected override void Dispose(bool disposing)
        {
            shopService.Dispose();
            base.Dispose(disposing);
        }

    }
}
