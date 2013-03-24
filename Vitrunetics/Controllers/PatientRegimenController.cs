using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vitrunetics.Controllers
{
    public class PatientRegimenController : Controller
    {
        private VitruneticsContext db = new VitruneticsContext();

        //
        // GET: /PatientRegimen/

        public ActionResult Index()
        {
            var patientregimen1 = db.PatientRegimen1.Include(p => p.Patient).Include(p => p.Regimen);
            return View(patientregimen1.ToList());
        }

        //
        // GET: /PatientRegimen/Details/5

        public ActionResult Details(int id = 0)
        {
            PatientRegimen patientregimen = db.PatientRegimen1.Find(id);
            if (patientregimen == null)
            {
                return HttpNotFound();
            }
            return View(patientregimen);
        }

        //
        // GET: /PatientRegimen/Create

        public ActionResult Create()
        {
            ViewBag.PatientID = new SelectList(db.Patients, "PatientID", "FName");
            ViewBag.RegimenID = new SelectList(db.Regimen1, "RegimenID", "RegimenName");
            return View();
        }

        //
        // POST: /PatientRegimen/Create

        [HttpPost]
        public ActionResult Create(PatientRegimen patientregimen)
        {
            if (ModelState.IsValid)
            {
                db.PatientRegimen1.Add(patientregimen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PatientID = new SelectList(db.Patients, "PatientID", "FName", patientregimen.PatientID);
            ViewBag.RegimenID = new SelectList(db.Regimen1, "RegimenID", "RegimenName", patientregimen.RegimenID);
            return View(patientregimen);
        }

        //
        // GET: /PatientRegimen/Edit/5

        public ActionResult Edit(int id = 0)
        {
            PatientRegimen patientregimen = db.PatientRegimen1.Find(id);
            if (patientregimen == null)
            {
                return HttpNotFound();
            }
            ViewBag.PatientID = new SelectList(db.Patients, "PatientID", "FName", patientregimen.PatientID);
            ViewBag.RegimenID = new SelectList(db.Regimen1, "RegimenID", "RegimenName", patientregimen.RegimenID);
            return View(patientregimen);
        }

        //
        // POST: /PatientRegimen/Edit/5

        [HttpPost]
        public ActionResult Edit(PatientRegimen patientregimen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patientregimen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PatientID = new SelectList(db.Patients, "PatientID", "FName", patientregimen.PatientID);
            ViewBag.RegimenID = new SelectList(db.Regimen1, "RegimenID", "RegimenName", patientregimen.RegimenID);
            return View(patientregimen);
        }

        //
        // GET: /PatientRegimen/Delete/5

        public ActionResult Delete(int id = 0)
        {
            PatientRegimen patientregimen = db.PatientRegimen1.Find(id);
            if (patientregimen == null)
            {
                return HttpNotFound();
            }
            return View(patientregimen);
        }

        //
        // POST: /PatientRegimen/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            PatientRegimen patientregimen = db.PatientRegimen1.Find(id);
            db.PatientRegimen1.Remove(patientregimen);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}