using KisKer.DAL;
using KisKer.Models;
using KisKer.ViewModels;
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
        public static List<NapiAdatokViewModel> AdatokList = new List<NapiAdatokViewModel>();
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
        public ActionResult Index(string selectedDate, string searchString, int? CategoryID)
        {
            AdatokTabla(searchString, CategoryID);
            PopulateCategoryDropDown();
            if (!String.IsNullOrEmpty(selectedDate))
            {
                var date = DateTime.Parse(selectedDate).ToShortDateString();                
                AdatokList = AdatokList.Where(p => p.ErtekesitesDates.ToShortDateString() == date).ToList();
            }
            if (CategoryID.HasValue)
            {
                AdatokList = AdatokList.Where(u => u.AruKategoriaID == CategoryID).ToList();
            }
            if (!String.IsNullOrEmpty(searchString))
            {
                AdatokList = AdatokList.Where(l => l.AruMegnevezes.ToLower()
                .Contains(searchString.ToLower()))
                .ToList();
            }
            return View();
        }
        [ChildActionOnly]
        public ActionResult AdatokTabla(string searchString, int? CategoryID)
        {
            AdatokList.Clear();
            var keszlet = _shopRepository.GetReszletek();
            foreach (var adat in keszlet)
            {
                AdatokList.Add(new NapiAdatokViewModel()
                {
                    ErtekesitesDates = adat.Ertekesites.ErtekesitesDatum,
                    AruID = adat.AruID,
                    AruKategoriaID = adat.AruKeszlet.AruKategoriaID,
                    AruMegnevezes = adat.AruKeszlet.AruMegnevezes,
                    AruKategoriaMegnevezes = adat.AruKeszlet.AruKategoria.AruKategoriaMegnevezes,
                    AruMennyiseg = adat.AruMennyiseg,
                    EgysegAr = adat.AruKeszlet.EgysegAr,
                    TeljesAr = adat.AruMennyiseg * adat.AruKeszlet.EgysegAr,
                    Mertekegyseg = adat.AruKeszlet.Mertekegyseg,
                    MertekegysegAzon = adat.AruKeszlet.MertekegysegAzon
                });
            }
            return PartialView("AdatokTabla");
        }




        #region Helpers
        public IList<ErtekesitesReszlet> GetReszletek()
        {
            return _shopRepository.GetReszletek();
        }
        //public IList<AruKeszlet> GetAruKeszlet()
        //{
        //    return _shopRepository.GetAruKeszlet();
        //}
        //public List<DateTime> GetDates(int id)
        //{
        //    return _shopRepository.GetDates(id);
        //}
        //public string GetKategoriaNev(int id)
        //{
        //    return _shopRepository.GetKategoriaNev(id);
        //}
        //public int GetKategoriaId(int id)
        //{
        //    return _shopRepository.GetKategoriaId(id);
        //}
        //public decimal GetEgysegAr(int id)
        //{
        //    return _shopRepository.GetEgysegAr(id);
        //}
        //public decimal GetTeljesAr(int id)
        //{
        //    return _shopRepository.GetTeljesAr(id);
        //}
        //public string GetMertekEgyseg(int id)
        //{
        //    return _shopRepository.GetMertekEgyseg(id);
        //}
        //public int GetMertekEgysegAzon(int id)
        //{
        //    return _shopRepository.GetMertekEgysegAzon(id);
        //}
        //public List<decimal> GetAruMennyiseg(int id)
        //{
        //    return _shopRepository.GetAruMennyiseg(id);
        //}
        //public string GetAruNev(int id)
        //{
        //    return _shopRepository.GetAruNev(id);
        //}
        private void PopulateCategoryDropDown(object selectedCategory = null)
        {            
            ViewBag.CategoryID = new SelectList(_shopRepository.GetCategories(), "AruKategoriaID", "AruKategoriaMegnevezes", selectedCategory);
        }        
        #endregion
    }
}