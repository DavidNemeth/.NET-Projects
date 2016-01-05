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
    public class GepJarmuvekController : Controller
    {
        private SzereloCegEntities db = new SzereloCegEntities();

        // GET: GepJarmuvek
        public ActionResult Index()
        {            
            var gepJarmuvek = db.GepJarmuvek.Include(g => g.Ugyfel);
            return View(gepJarmuvek.ToList());
        }

        // GET: GepJarmuvek/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GepJarmu gepJarmu = db.GepJarmuvek.Find(id);
            if (gepJarmu == null)
            {
                return HttpNotFound();
            }
            return View(gepJarmu);
        }

        // GET: GepJarmuvek/Create
        public ActionResult Create()
        {
            TulajdonosDropDown();
            return View();
        }

        // POST: GepJarmuvek/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Marka,Tipus,Rendszam,GyartasiEv,UgyfelID")] GepJarmu gepJarmu)
        {
            if (ModelState.IsValid)
            {
                db.GepJarmuvek.Add(gepJarmu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            TulajdonosDropDown(gepJarmu.UgyfelID);
            return View(gepJarmu);
        }
        public ActionResult CreateForUgyfel()
        {
            
            TulajdonosDropDown();
            return View();
        }

        // POST: GepJarmuvek/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateForUgyfel([Bind(Include = "ID,Marka,Tipus,Rendszam,GyartasiEv,UgyfelID")] GepJarmu gepJarmu)
        {
            if (ModelState.IsValid)
            {
                db.GepJarmuvek.Add(gepJarmu);
                db.SaveChanges();
                return RedirectToAction("Index", "Ugyfelek");
            }

            TulajdonosDropDown(gepJarmu.UgyfelID);
            return View(gepJarmu);
        }

        // GET: GepJarmuvek/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GepJarmu gepJarmu = db.GepJarmuvek.Find(id);
            if (gepJarmu == null)
            {
                return HttpNotFound();
            }
            TulajdonosDropDown(gepJarmu.UgyfelID);
            return View(gepJarmu);
        }

        // POST: GepJarmuvek/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Marka,Tipus,Rendszam,GyartasiEv,UgyfelID")] GepJarmu gepJarmu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gepJarmu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            TulajdonosDropDown(gepJarmu.UgyfelID);
            return View(gepJarmu);
        }

        // GET: GepJarmuvek/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GepJarmu gepJarmu = db.GepJarmuvek.Find(id);
            if (gepJarmu == null)
            {
                return HttpNotFound();
            }
            return View(gepJarmu);
        }

        // POST: GepJarmuvek/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GepJarmu gepJarmu = db.GepJarmuvek.Find(id);
            db.GepJarmuvek.Remove(gepJarmu);
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


        #region helper
        private void TulajdonosDropDown(object selectedTulajdonos = null)
        {
            var Query = from s in db.Ugyfelek
                        orderby s.FelvetelIdeje descending
                        select s;
            ViewBag.UgyfelID = new SelectList(Query, "ID", "UgyfelNev", selectedTulajdonos);
        }
        #endregion

    }
}
