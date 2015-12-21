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

namespace MvcNews.Controllers
{
    public class NewsController : Controller
    {
        private NewsDbContext db = new NewsDbContext();

       
        public ActionResult Index()
        {
            var news = db.News.Include(n => n.Category).Include(t => t.NewsTags);
            return View(news.ToList());
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
       
        public ActionResult Create()
        {            
            var news = new News();            
            news.NewsTags = new List<NewsTag>();
            TagList(news);
            CategoryList();            
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Tittle,Description,Body,Published,PostedDate,Modified,CategoryID")] News news, string[] checkedTag)
        {

            news.PostedDate = DateTime.Now;                       
           
            if (checkedTag != null)
            {
                news.NewsTags = new List<NewsTag>();
                foreach (var tag in checkedTag)
                {
                    var addtag = db.NewsTags.Find(int.Parse(tag));
                    news.NewsTags.Add(addtag);
                }
            }          
            if (ModelState.IsValid)
            {
                db.News.Add(news);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            TagList(news);
            CategoryList(news.CategoryID);
            return View(news);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.News
                .Include(n => n.NewsTags)
                .Where(n => n.Id == id)
                .Single();
            if (news == null)
            {
                return HttpNotFound();
            }
            CategoryList(news.CategoryID);
            TagList(news);
            return View(news);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, string[] checkedTag)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var UpdatePost = db.News
                .Include(n => n.NewsTags)
                .Where(n => n.Id == id)
                .Single();
            UpdatePost.Modified = DateTime.Now;
                        
                if (TryUpdateModel(UpdatePost, "", new string[] {                    
                    "CategoryID",
                    "Tittle",
                    "Description",
                    "Body",
                    "Published",
                    "Modified" }))
                {
                    EditPostTags(checkedTag, UpdatePost);
                    db.Entry(UpdatePost).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                        
            CategoryList(UpdatePost.CategoryID);
            TagList(UpdatePost);
            return View(UpdatePost);
        }



        public ActionResult Delete(int? id)
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
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            News news = db.News.Find(id);
            db.News.Remove(news);
            db.SaveChanges();
            return RedirectToAction("Index");
        }











# region helpers
        private void CategoryList(object selectedCategory = null)
        {
            var category = from d in db.Categories
                           orderby d.CategoryName
                           select d;
            ViewBag.CategoryID = new SelectList(category, "CategoryId", "CategoryName", selectedCategory);
        }

        private void TagList(News news)
        {
            var allTags = db.NewsTags;
            var newsTags = new HashSet<int>(news.NewsTags.Select(t => t.TagId));
            var Model = new List<NewsTagsViewModel>();
            foreach (var tag in allTags)
            {
                Model.Add(new NewsTagsViewModel
                {
                    TagId = tag.TagId,
                    TagName = tag.TagName,
                    Checked = newsTags.Contains(tag.TagId)
                });
            }
            ViewBag.Tags = Model;
        }
        private void EditPostTags(string[] checkedTag, News newsToUpdate)
        {
            if (checkedTag == null)
            {
                newsToUpdate.NewsTags = new List<NewsTag>();
                return;
            }
            var selectedTag = new HashSet<string>(checkedTag);
            var newstags = new HashSet<int>(newsToUpdate.NewsTags.Select(t => t.TagId));
            foreach (var tag in db.NewsTags)
            {
                var tagidstring = tag.TagId.ToString();

                if (selectedTag.Contains(tagidstring))
                {
                    if (!newstags.Contains(tag.TagId))
                    {
                        newsToUpdate.NewsTags.Add(tag);
                    }
                }
                else
                {
                    if (newstags.Contains(tag.TagId))
                    {
                        newsToUpdate.NewsTags.Remove(tag);
                    }
                }                
            }                        
        }        



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        #endregion
    }
}
