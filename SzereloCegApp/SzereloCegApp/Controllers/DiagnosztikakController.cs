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
    public class DiagnosztikakController : Controller
    {
        private SzereloCegEntities db = new SzereloCegEntities();

        // GET: Diagnosztikak
        public ActionResult Index(int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            var diag = db.Diagnosztikák
                .OrderBy(d => d.HibaNeve);
            return View(diag.ToPagedList(pageNumber,pageSize));
        }

        // GET: Diagnosztikak/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diagnosztika diagnosztika = db.Diagnosztikák.Find(id);
            if (diagnosztika == null)
            {
                return HttpNotFound();
            }
            return View(diagnosztika);
        }

        // GET: Diagnosztikak/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Diagnosztikak/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,HibaNeve,MunkaIdo,Anyagköltseg")] Diagnosztika diagnosztika)
        {
            if (ModelState.IsValid)
            {
                db.Diagnosztikák.Add(diagnosztika);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(diagnosztika);
        }

        // GET: Diagnosztikak/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diagnosztika diagnosztika = db.Diagnosztikák.Find(id);
            if (diagnosztika == null)
            {
                return HttpNotFound();
            }
            return View(diagnosztika);
        }

        // POST: Diagnosztikak/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,HibaNeve,Anyagköltseg,MunkaIdo")] Diagnosztika diagnosztika)
        {
            if (ModelState.IsValid)
            {
                db.Entry(diagnosztika).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(diagnosztika);
        }

        // GET: Diagnosztikak/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diagnosztika diagnosztika = db.Diagnosztikák.Find(id);
            if (diagnosztika == null)
            {
                return HttpNotFound();
            }
            return View(diagnosztika);
        }

        // POST: Diagnosztikak/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Diagnosztika diagnosztika = db.Diagnosztikák.Find(id);
            db.Diagnosztikák.Remove(diagnosztika);
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
