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
    public class KliensekController : Controller
    {
        private SzereloCegEntities db = new SzereloCegEntities();

        // GET: Kliensek
        public ActionResult Index()
        {
            var kliensek = db.Kliensek.Include(k => k.Szerelo);
            return View(kliensek.ToList());
        }

        // GET: Kliensek/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kliens kliens = db.Kliensek.Find(id);
            if (kliens == null)
            {
                return HttpNotFound();
            }
            return View(kliens);
        }

        // GET: Kliensek/Create
        public ActionResult Create()
        {            
            ViewBag.SzereloID = new SelectList(db.Szerelok, "ID", "Vezetéknév");
            return View();
        }

        // POST: Kliensek/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Vezetéknév,Keresztnév,Szulido,FelvetelIdeje,Surgos,SzereloID")] Kliens kliens)
        {
            kliens.FelvetelIdeje = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Kliensek.Add(kliens);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SzereloID = new SelectList(db.Szerelok, "ID", "Vezetéknév", kliens.SzereloID);
            return View(kliens);
        }

        // GET: Kliensek/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kliens kliens = db.Kliensek.Find(id);
            if (kliens == null)
            {
                return HttpNotFound();
            }
            ViewBag.SzereloID = new SelectList(db.Szerelok, "ID", "Vezetéknév", kliens.SzereloID);
            return View(kliens);
        }

        // POST: Kliensek/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Vezetéknév,Keresztnév,Szulido,FelvetelIdeje,Surgos,SzereloID")] Kliens kliens)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kliens).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SzereloID = new SelectList(db.Szerelok, "ID", "Vezetéknév", kliens.SzereloID);
            return View(kliens);
        }

        // GET: Kliensek/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kliens kliens = db.Kliensek.Find(id);
            if (kliens == null)
            {
                return HttpNotFound();
            }
            return View(kliens);
        }

        // POST: Kliensek/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kliens kliens = db.Kliensek.Find(id);
            db.Kliensek.Remove(kliens);
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
