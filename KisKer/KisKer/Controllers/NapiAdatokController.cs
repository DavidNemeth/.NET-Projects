using KisKer.DAL;
using KisKer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KisKer.Controllers
{
    public class NapiAdatokController : Controller
    {
        #region repo
        private IShopRepository _shopRepository;

        public NapiAdatokController()
        {
            _shopRepository = new ShopRepository(new KiskerEntities());
        }
        public NapiAdatokController(IShopRepository shopRepository)
        {
            _shopRepository = shopRepository;
        }
        #endregion




        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
    }
}