using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SzereloCegApp.DAL;
using SzereloCegApp.Models;

namespace SzereloCegApp.Controllers
{
    public class PostsController : Controller
    {
        private SzereloCegEntities db = new SzereloCegEntities();

        // GET: Posts
        public ActionResult Index(int? SzereloID, int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);            
            SzereloDropDown();
            var posts = db.Posts.Include(p => p.Szerelo).OrderBy(p => p.PostedDate);
            if (SzereloID.HasValue)
            {
                posts = posts.Where(u => u.SzereloID == SzereloID).OrderBy(p => p.PostedDate);
            }
            return View(posts.ToPagedList(pageNumber, pageSize));
        }

        // GET: Posts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // GET: Posts/Create
        public ActionResult Create()
        {
            SzereloDropDown();
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Description,Body,PostedDate,SzereloID")] Post post)
        {
            post.PostedDate = System.DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            SzereloDropDown(post.SzereloID);
            return View(post);
        }

        // GET: Posts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            SzereloDropDown(post.SzereloID);
            return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Description,Body,PostedDate,SzereloID")] Post post)
        {
            post.PostedDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            SzereloDropDown(post.SzereloID);
            return View(post);
        }

        // GET: Posts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = db.Posts.Find(id);
            db.Posts.Remove(post);
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
        private void SzereloDropDown(object selectedSzerelo = null)
        {
            var Query = from s in db.Szerelok
                        orderby s.Vezetéknév
                        select s;
            ViewBag.SzereloID = new SelectList(Query, "ID", "SzereloNev", selectedSzerelo);
        }
    }
}
