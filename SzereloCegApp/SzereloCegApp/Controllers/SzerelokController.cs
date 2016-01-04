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
    public class SzerelokController : Controller
    {
        private SzereloCegEntities db = new SzereloCegEntities();

        // GET: Szerelok
        public ActionResult Index()
        {
            return View(db.Szerelok.ToList());
        }

        // GET: Szerelok/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Szerelo szerelo = db.Szerelok.Find(id);
            if (szerelo == null)
            {
                return HttpNotFound();
            }
            return View(szerelo);
        }

        // GET: Szerelok/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Szerelok/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Vezetéknév,Keresztnév")] Szerelo szerelo)
        {
            if (ModelState.IsValid)
            {
                db.Szerelok.Add(szerelo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(szerelo);
        }

        // GET: Szerelok/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Szerelo szerelo = db.Szerelok.Find(id);
            if (szerelo == null)
            {
                return HttpNotFound();
            }
            return View(szerelo);
        }

        // POST: Szerelok/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Vezetéknév,Keresztnév")] Szerelo szerelo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(szerelo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(szerelo);
        }

        // GET: Szerelok/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Szerelo szerelo = db.Szerelok.Find(id);
            if (szerelo == null)
            {
                return HttpNotFound();
            }
            return View(szerelo);
        }

        // POST: Szerelok/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Szerelo szerelo = db.Szerelok.Find(id);
            db.Szerelok.Remove(szerelo);
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
