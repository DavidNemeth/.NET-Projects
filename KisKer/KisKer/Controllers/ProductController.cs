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
    public class ProductController : Controller
    {
        #region repo
        private IShopRepository _shopRepository;
        public int PageSize = 6;
        public ProductController()
        {
            _shopRepository = new ShopRepository(new KiskerEntities());
        }
        public ProductController(IShopRepository shopRepository)
        {
            _shopRepository = shopRepository;
        }
        #endregion
        public ViewResult List(string searchString, int? CategoryID, int page = 1)
        {
            AruListViewModel model = new AruListViewModel
            {
                Products = _shopRepository.GetAruKeszlet()
                       .OrderBy(p => p.AruID)
                       .Skip((page - 1) * PageSize)
                       .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                }
            };
            PopulateCategoryDropDown();            
            if (!String.IsNullOrEmpty(searchString))
            {
                model = new AruListViewModel
                {
                    Products = _shopRepository.GetAruKeszlet()
                        .Where(p => p.AruMegnevezes.ToLower().Contains(searchString.ToLower()))
                        .OrderBy(p => p.AruID)
                        .Skip((page - 1) * PageSize)
                        .Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                    }
                };                
            }
            if (CategoryID.HasValue)
            {
                model = new AruListViewModel
                {
                    Products = _shopRepository.GetAruKeszlet()
                        .Where(p => p.AruKategoriaID == CategoryID)
                        .OrderBy(p => p.AruID)
                        .Skip((page - 1) * PageSize)
                        .Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                    }
                };               
            }
            return View(model);
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