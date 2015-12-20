using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcNews.Models;

namespace MvcNews.Controllers
{
    public class NewsTagsController : Controller
    {
        private NewsDbContext db = new NewsDbContext();

        // GET: NewsTags
        public ActionResult Index()
        {
            return View(db.NewsTags.ToList());
        }

        // GET: NewsTags/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsTag newsTag = db.NewsTags.Find(id);
            if (newsTag == null)
            {
                return HttpNotFound();
            }
            return View(newsTag);
        }

        // GET: NewsTags/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NewsTags/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TagId,TagName")] NewsTag newsTag)
        {
            if (ModelState.IsValid)
            {
                db.NewsTags.Add(newsTag);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(newsTag);
        }

        // GET: NewsTags/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsTag newsTag = db.NewsTags.Find(id);
            if (newsTag == null)
            {
                return HttpNotFound();
            }
            return View(newsTag);
        }

        // POST: NewsTags/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TagId,TagName")] NewsTag newsTag)
        {
            if (ModelState.IsValid)
            {
                db.Entry(newsTag).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newsTag);
        }

        // GET: NewsTags/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsTag newsTag = db.NewsTags.Find(id);
            if (newsTag == null)
            {
                return HttpNotFound();
            }
            return View(newsTag);
        }

        // POST: NewsTags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NewsTag newsTag = db.NewsTags.Find(id);
            db.NewsTags.Remove(newsTag);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
