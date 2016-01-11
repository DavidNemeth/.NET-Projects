using KisKer.DAL;
using KisKer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KisKer.Controllers
{
    public class AdatFelvitelController : Controller
    {
        private IShopRepository _shopRepository;

        public AdatFelvitelController()
        {
            _shopRepository = new ShopRepository(new KiskerEntities());
        }
        public AdatFelvitelController(IShopRepository shopRepository)
        {
            _shopRepository = shopRepository;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
    }
}