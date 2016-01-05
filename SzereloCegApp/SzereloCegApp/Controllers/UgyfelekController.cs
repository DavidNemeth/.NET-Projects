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
        public ActionResult Index(string sortOrder, string searchString, int? SzereloID)
        {
            SzereloDropDown();
            //TODO: Sorting/ordering
            ViewBag.NameSort = String.IsNullOrEmpty(sortOrder) ? "név csökkenő" : "";
            ViewBag.FelvetelSort = sortOrder == "FelvetelIdeje" ? "FelvetelIdeje csökkenő" : "FelvetelIdeje";
            ViewBag.SzulSort = sortOrder == "Szulido" ? "Szulido csökkenő" : "Szulido";
            //ViewBag.Gepjarmu = sortOrder == "Gepjarmu" ? "Gepjarmu desc" : "Gepjarmu";
            ViewBag.SzereloSort = sortOrder == "Szerelo" ? "Szerelo desc" : "Szerelo";
            //TODO: filtering
            var ugyfelek = db.Ugyfelek
                .Include(u => u.Szerelo)
                .Include(u => u.GepJarmu);

            if (SzereloID.HasValue)
            {
                ugyfelek = ugyfelek.Where(u => u.SzereloID == SzereloID);
            }
            if (!String.IsNullOrEmpty(searchString))
            {
                ugyfelek = ugyfelek.Where(u => u.Vezetéknév.ToLower().Contains(searchString.ToLower())
                || u.Keresztnév.ToLower().Contains(searchString.ToLower()));                    
            }

            switch (sortOrder)
            {
                case "név csökkenő":
                    ugyfelek = ugyfelek
                        .OrderByDescending(u => u.Vezetéknév)
                        .ThenByDescending(u => u.Keresztnév);
                    break;
                case "FelvetelIdeje":
                    ugyfelek = ugyfelek.OrderBy(p => p.FelvetelIdeje);
                    break;
                case "FelvetelIdeje csökkenő":
                    ugyfelek = ugyfelek.OrderByDescending(p => p.FelvetelIdeje);
                    break;
                case "Szulido":
                    ugyfelek = ugyfelek.OrderBy(p => p.Szulido);
                    break;
                case "Szulido csökkenő":
                    ugyfelek = ugyfelek.OrderByDescending(p => p.Szulido);
                    break;
                //case "Gepjarmu":                                
                //    ugyfelek = ugyfelek.OrderBy(p => p.GepJarmu.OrderBy(n => n.Marka));
                //    break;
                //case "Gepjarmu desc":
                //    ugyfelek = ugyfelek.OrderByDescending(p => p.GepJarmu.OrderBy(n => n.Marka));
                //    break;
                case "Szerelo":
                    ugyfelek = ugyfelek.OrderBy(p => p.Szerelo.Vezetéknév);
                    break;
                case "Szerelo desc":
                    ugyfelek = ugyfelek.OrderByDescending(p => p.Szerelo.Vezetéknév);
                    break;

                default:
                    ugyfelek = ugyfelek
                        .OrderBy(u => u.Vezetéknév)
                        .ThenBy(u => u.Keresztnév);
                    break;
            }
            return View(ugyfelek.ToList());   
        }

        // GET: Ugyfelek/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ugyfel ugyfel = db.Ugyfelek
                .Include(s => s.GepJarmu)
                .Where(s => s.ID == id).SingleOrDefault();
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
                return RedirectToAction("CreateForUgyfel","GepJarmuvek");
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
            try
            {                
                db.Ugyfelek.Remove(ugyfel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (DataException ex)
            {
                if (ex.InnerException.InnerException.Message.Contains("FK"))
                {
                    ModelState.AddModelError("", "Tulajdonos nem törölhető, amíg Gépkocsija szerelésre vár, ha a szerelést befejezte először törölje a járművet.");
                    
                }
                else
                {
                    ModelState.AddModelError("", "Elfárdadt az adatbázis, próbálja meg később.");
                }
            }

            return View(ugyfel);
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
