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
    public class UgyfelekController : Controller
    {
        private SzereloCegEntities db = new SzereloCegEntities();

        // GET: Ugyfelek
        public ActionResult Index()
        {
            var ugyfelek = db.Ugyfelek.Include(u => u.Szerelo);
            return View(ugyfelek.ToList());   
        }

        // GET: Ugyfelek/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ugyfel ugyfel = db.Ugyfelek.Find(id);
            if (ugyfel == null)
            {
                return HttpNotFound();
            }
            return View(ugyfel);
        }

        // GET: Ugyfelek/Create
        public ActionResult Create()
        {
            SzereloDropDown();
            return View();
        }

        // POST: Ugyfelek/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Vezetéknév,Keresztnév,Szulido,FelvetelIdeje,Surgos,SzereloID")] Ugyfel ugyfel)
        {

            if (ModelState.IsValid)
            {
                db.Ugyfelek.Add(ugyfel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            SzereloDropDown(ugyfel.SzereloID);
            return View(ugyfel);
        }

        // GET: Ugyfelek/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ugyfel ugyfel = db.Ugyfelek.Find(id);
            if (ugyfel == null)
            {
                return HttpNotFound();
            }
            SzereloDropDown(ugyfel.SzereloID);
            return View(ugyfel);
        }

        // POST: Ugyfelek/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Vezetéknév,Keresztnév,Szulido,FelvetelIdeje,Surgos,SzereloID")] Ugyfel ugyfel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ugyfel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            SzereloDropDown(ugyfel.SzereloID);
            return View(ugyfel);
        }

        // GET: Ugyfelek/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ugyfel ugyfel = db.Ugyfelek.Find(id);
            if (ugyfel == null)
            {
                return HttpNotFound();
            }
            return View(ugyfel);
        }

        // POST: Ugyfelek/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ugyfel ugyfel = db.Ugyfelek.Find(id);
            db.Ugyfelek.Remove(ugyfel);
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


        #region helpers

        private void SzereloDropDown(object selectedSzerelo = null)
        {
            var Query = from s in db.Szerelok
                        orderby s.Vezetéknév
                        select s;
            ViewBag.SzereloID = new SelectList(Query, "ID", "SzereloNev", selectedSzerelo);
        }

        #endregion
    }
}
