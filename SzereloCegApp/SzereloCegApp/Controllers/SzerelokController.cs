using System;
using System.Collections.Generic;
using PagedList;
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
        public ActionResult Index(int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            var szerelok = db.Szerelok
                .Include(u => u.Ugyfelek)
                .OrderBy(u => u.Keresztnév);             
            return View(szerelok.ToPagedList(pageNumber,pageSize));
        }

        // GET: Szerelok/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Szerelo szerelo = db.Szerelok
                .Include(s => s.Ugyfelek)
                .Where(s => s.ID == id).SingleOrDefault();
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
        public ActionResult Create([Bind(Include = "ID,Vezetéknév,Keresztnév,Oraber")] Szerelo szerelo)
        {
            if (ModelState.IsValid)
            {
                db.Szerelok.Add(szerelo);
                db.SaveChanges();
                return RedirectToAction("Index", "Szerelok");
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
        public ActionResult Edit([Bind(Include = "ID,Vezetéknév,Keresztnév,Oraber")] Szerelo szerelo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(szerelo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Ugyfelek");
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
            try
            {
                db.Szerelok.Remove(szerelo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (DataException ex)
            {
                if (ex.InnerException.InnerException.Message.Contains("FK"))
                {
                    ModelState.AddModelError("", "Szerelő nem törölhető, amíg ügyfele van.");
                }
                else
                {
                    ModelState.AddModelError("","Elfárdadt az adatbázis, próbálja meg később.");
                }
            }
            return View(szerelo);      
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
