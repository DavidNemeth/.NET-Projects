using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HospitalApp.DAL;
using HospitalApp.Models;
using HospitalApp.ViewModels;

namespace HospitalApp.Controllers
{
    public class PatientsController : Controller
    {
        private HospitalEntities db = new HospitalEntities();

        // GET: Patients
        public ActionResult Index()
        {
            var patients = db.Patients.Include(p => p.Doctor);
            return View(patients.ToList());
        }

        // GET: Patients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // GET: Patients/Create
        public ActionResult Create()
        {
            var patient = new Patient();
            patient.Conditions = new List<Condition>();
            PopulateAssignedCondition(patient);
            PopulateDropDownList();
            return View();
        }

        // POST: Patients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TB,FirstName,LastName,DoB,YrVisits,DoctorID")] Patient patient, string[] SelectedCondition, string[] NotSelectedCondition)
        {
            if (SelectedCondition != null)
            {
                patient.Conditions = new List<Condition>();
                foreach (var con in SelectedCondition)
                {
                    var addcondition = db.Conditions.Find(int.Parse(con));
                    patient.Conditions.Add(addcondition);
                }
            }            
            if (ModelState.IsValid)
            {
                db.Patients.Add(patient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            PopulateAssignedCondition(patient);
            PopulateDropDownList(patient.DoctorID);
            return View(patient);
        }

        // GET: Patients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients
                .Include(p => p.Conditions)
                .Where(i => i.ID == id)
                .Single();
            if (patient == null)
            {
                return HttpNotFound();
            }
            PopulateAssignedCondition(patient);
            PopulateDropDownList(patient.DoctorID);
            return View(patient);
        }

        // POST: Patients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id,string[] SelectedCon,string[] NotSelectedCon)
        {
            var patientToUpdate = db.Patients
                .Include(p => p.Conditions)
                .Where(i => i.ID == id)
                .Single();                
            if (TryUpdateModel(patientToUpdate, "", new string[] {
                "ID",
                "TB",
                "FirstName",
                "LastName",
                "DoB",
                "YrVisits",
                "DoctorID"}))
                if (ModelState.IsValid)
            {
                UpdateConditions(SelectedCon, patientToUpdate);
                db.Entry(patientToUpdate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            PopulateAssignedCondition(patientToUpdate);
            PopulateDropDownList(patientToUpdate.DoctorID);
            return View(patientToUpdate);
        }

        // GET: Patients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // POST: Patients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Patient patient = db.Patients.Find(id);
            db.Patients.Remove(patient);
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

        private void PopulateDropDownList(object selectedDoctor = null)
        {
            var Query = from s in db.Doctors
                        orderby s.LastName 
                        select s;
            ViewBag.DoctorID = new SelectList(Query, "ID", "DoctorName", selectedDoctor);
        }
        private void PopulateAssignedCondition(Patient patient)
        {
            var allCondition = db.Conditions;
            var pConditions = new HashSet<int>(patient.Conditions.Select(d => d.ID));
            var viewModelSelected = new List<PatientConditionsViewModel>();
            var viewModelNotSelected = new List<PatientConditionsViewModel>();
            foreach (var con in allCondition)
            {
                if (pConditions.Contains(con.ID))
                {
                    viewModelSelected.Add(new PatientConditionsViewModel
                    {
                        ConditionID = con.ID,
                        ConditionName = con.ConditionName,
                        Assigned = true
                    });
                }
                else
                {
                    viewModelNotSelected.Add(new PatientConditionsViewModel
                    {
                        ConditionID = con.ID,
                        ConditionName = con.ConditionName,
                        Assigned = true
                    });
                }
            }
            ViewBag.SelectedCon = new MultiSelectList(viewModelSelected, "ConditionID", "ConditionName");
            ViewBag.NotSelectedCon = new MultiSelectList(viewModelNotSelected, "ConditionID", "ConditionName");

        }
        private void UpdateConditions(string[] selectedConditions, Patient patientToUpdate)
        {
            if (selectedConditions == null)
            {
                patientToUpdate.Conditions = new List<Condition>();
                return;
            }
            var selectedHibakHash = new HashSet<string>(selectedConditions); //checkbox diagok
            var autoHibak = new HashSet<int>(patientToUpdate.Conditions.Select(g => g.ID));
            foreach (var hiba in db.Conditions)
            {
                string hibaid = hiba.ID.ToString();
                if (selectedHibakHash.Contains(hibaid))
                {
                    if (!autoHibak.Contains(hiba.ID))
                    {
                        patientToUpdate.Conditions.Add(hiba);
                    }
                }
                else
                {
                    if (autoHibak.Contains(hiba.ID))
                    {
                        patientToUpdate.Conditions.Remove(hiba);
                    }
                }
            }
        }

        #endregion
    }
}
