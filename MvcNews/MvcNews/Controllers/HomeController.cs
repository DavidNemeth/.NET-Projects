using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcNews.Models;
using MvcNews.ViewModel;
using System.Data.Entity.Infrastructure;
using MvcNews.DAL;

namespace MvcNews.Controllers
{
    public class HomeController : Controller
    {
        private INewsRepository repo;
        public static List<NewsViewModel> newsList = new List<NewsViewModel>();
        public HomeController()
        {
            repo = new NewsRepository(new NewsDbContext());
        }
        public HomeController(INewsRepository repository)
        {
            repo = repository;
        }
        private NewsDbContext db = new NewsDbContext();

        public ActionResult Posts(int? CatId,int? TagId)
        {
            newsList.Clear();
            var news = repo.GetAllNews();
            var categories = repo.GetAllCategory();
            var tags = repo.GetAllTags();
            if (CatId == null & TagId == null)
            {
                newsList.Clear();
                foreach (var post in news)
                {
                    newsList.Add(new NewsViewModel()
                    {
                        News = news,
                        Id = post.Id,
                        Tittle = post.Tittle,
                        Description = post.Description,
                        Body = post.Body,
                        PostedDate = post.PostedDate,
                        Modified = post.Modified,
                        Category = post.Category,
                        CategoryID = post.CategoryID,
                        NewsTags = post.NewsTags,
                        AllCategory = categories,
                        AllTags = tags
                    });
                }
                ViewBag.AllCategory = categories;
                CategoryList();
                ViewBag.AllTags = tags;
                return PartialView("Posts");
            }
            else
            {
                newsList.Clear();
                var tfilter = repo.CategoryFilter(CatId);               
                foreach (var post in tfilter)
                {                    
                    newsList.Add(new NewsViewModel()
                    {
                        News = news,
                        Id = post.Id,
                        Tittle = post.Tittle,
                        Description = post.Description,
                        Body = post.Body,
                        PostedDate = post.PostedDate,
                        Modified = post.Modified,
                        Category = post.Category,
                        CategoryID = post.CategoryID,
                        NewsTags = post.NewsTags,
                        AllCategory = categories,
                        AllTags = tags
                    });
                }
                ViewBag.AllCategory = categories;
                CategoryList();
                ViewBag.AllTags = tags;
                return PartialView("Posts");
            }    
            
        }

        public ActionResult Index(int? CatId,int? TagId)
        {            
            //var news = db.News.Include(n => n.Category)
            //    .Include(t => t.NewsTags)
            //    .Where(p => p.Published == true)
            //    .OrderByDescending(p => p.PostedDate);
            //CategoryList();
            //TagList();
            Posts(CatId,TagId);
            return View(/*news.ToList()*/);
        }        

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

























        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        #region helpers
        private void CategoryList(object selectedCategory = null)
        {
            var category = repo.GetAllCategory();
            ViewBag.Category = new SelectList(category, "CategoryId", "CategoryName", selectedCategory);
        }
        private void TagList(object selectedCategory = null)
        {
            var tags = from t in db.NewsTags
                       orderby t.TagName
                       select t;
            ViewBag.TagID = new SelectList(tags,"TagId", "TagName", selectedCategory);
        }

        public IList<News> GetAllNews()
        {
            return repo.GetAllNews();               
        }
        public IList<Category> GetAllCategory()
        {
            return repo.GetAllCategory();
        }
        public IList<NewsTag> GetAllTags()
        {
            return repo.GetAllTags();
        }
        public IList<News> CategoryFilter(int? CatID)
        {
            return repo.CategoryFilter(CatID);
        }

        #endregion
    }
}