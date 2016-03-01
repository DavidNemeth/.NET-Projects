using KisKer.DAL;
using KisKer.Models;
using KisKer.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace KisKer.Controllers
{
    public class CartController : Controller
    {
        #region repo
        private IShopRepository _shopRepository;
        private KiskerEntities db = new KiskerEntities();
        public int PageSize = 6;
        public CartController()
        {
            _shopRepository = new ShopRepository(new KiskerEntities());
        }
        public CartController(IShopRepository shopRepository)
        {
            _shopRepository = shopRepository;
        }
        #endregion
        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(
                new CartIndexViewModel { Cart = cart, ReturnUrl = returnUrl });
        }
        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }
        public RedirectToRouteResult AddToCart(Cart cart, int AruID, string returnUrl)
        {
            AruKeszlet product = _shopRepository.GetAruKeszlet().FirstOrDefault(p => p.AruID == AruID);

            if (product != null)
            {
                cart.AddItem(product, 1);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int AruID, string returnUrl)
        {
            AruKeszlet product = _shopRepository.GetAruKeszlet().FirstOrDefault(p => p.AruID == AruID);

            if (product != null)
            {
                cart.RemoveLine(product);
            }

            return RedirectToAction("Index", new { returnUrl });
        }
        public ActionResult Checkout(Cart cartline)
        {
            var selectedDate = DateTime.Now;
            CartIndexViewModel model = new CartIndexViewModel();
            model.Cart = cartline;
            foreach (var item in model.Cart.Lines)
            {
                foreach (var date in item.Product.ErtekesitesReszletek)
                {
                    date.Ertekesites.ErtekesitesDatum = selectedDate;
                }
            }

            return View(model);
        }
        [HttpPost]
        public ActionResult Checkout(Cart cartline, string selectedDate)
        {
            if (selectedDate == null)
            {
                selectedDate = DateTime.Today.ToShortDateString();
            }
            DateTime date = Convert.ToDateTime(selectedDate);
            if (ModelState.IsValid)
            {
                Ertekesites ertekesites = new Ertekesites
                {
                    ErtekesitesDatum = date
                };
                db.Ertekesitesek.Add(ertekesites);
                db.SaveChanges();
                try
                {
                    if (cartline == null)
                    {
                        ModelState.AddModelError("", "Nincs mit feltölteni.");
                        return View(new CartIndexViewModel());
                    }
                    foreach (var item in cartline.Lines.ToList())
                    {
                        if (item.AruMennyiseg < 1)
                        {
                            ModelState.AddModelError("", "Nincs mit feltölteni.");
                            return View(new CartIndexViewModel());
                        }
                        else
                        {
                            var keszlet = db.AruKeszletek                                
                                .Where(i => i.AruID == item.Product.AruID)
                                .Single();                            
                            if (item.AruMennyiseg > keszlet.Raktarkeszlet)
                            {
                                ModelState.AddModelError("", "Sajnáljuk Nincs elegendő áru készleten.");
                                return View(new CartIndexViewModel());
                            }
                            if (TryUpdateModel(keszlet,"",new string[] { "Raktarkeszlet" }))
                            {
                                keszlet.Raktarkeszlet = keszlet.Raktarkeszlet - item.AruMennyiseg;
                                db.SaveChanges();
                            }
                            ErtekesitesReszlet reszletek = new ErtekesitesReszlet();
                            reszletek.AruID = item.Product.AruID;
                            reszletek.AruMennyiseg = item.AruMennyiseg;
                            db.ErtekesitesReszletek.Add(reszletek);
                            reszletek.ErtekesitesID = ertekesites.ErtekesitesID;
                            db.SaveChanges();
                        }
                    }
                    cartline.Clear();
                    return RedirectToAction("Index", "NapiAdatok");
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Sajnáljuk Nincs elegendő áru készleten.");
                }
            }
            return View(new CartIndexViewModel());
        }

        #region Helpers
        public IList<ErtekesitesReszlet> GetReszletek()
        {
            return _shopRepository.GetReszletek();
        }
        public IList<AruKeszlet> GetAruKeszlet()
        {
            return _shopRepository.GetAruKeszlet();
        }
        #endregion helpers
    }
}
