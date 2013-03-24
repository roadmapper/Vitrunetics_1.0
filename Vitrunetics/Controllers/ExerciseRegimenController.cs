using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vitrunetics.Controllers
{
    public class ExerciseRegimenController : Controller
    {
        private VitruneticsContext db = new VitruneticsContext();

        //
        // GET: /ExerciseRegimen/

        public ActionResult Index()
        {
            var exerciseregimen1 = db.ExerciseRegimen1.Include(e => e.Exercise).Include(e => e.Regimen);
            return View(exerciseregimen1.ToList());
        }

        //
        // GET: /ExerciseRegimen/Details/5

        public ActionResult Details(int id = 0)
        {
            ExerciseRegimen exerciseregimen = db.ExerciseRegimen1.Find(id);
            if (exerciseregimen == null)
            {
                return HttpNotFound();
            }
            return View(exerciseregimen);
        }

        //
        // GET: /ExerciseRegimen/Create

        public ActionResult Create()
        {
            ViewBag.ExerciseID = new SelectList(db.Exercises, "ExerciseID", "Name");
            ViewBag.RegimenID = new SelectList(db.Regimen1, "RegimenID", "RegimenName");
            return View();
        }

        //
        // POST: /ExerciseRegimen/Create

        [HttpPost]
        public ActionResult Create(ExerciseRegimen exerciseregimen)
        {
            if (ModelState.IsValid)
            {
                db.ExerciseRegimen1.Add(exerciseregimen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ExerciseID = new SelectList(db.Exercises, "ExerciseID", "Name", exerciseregimen.ExerciseID);
            ViewBag.RegimenID = new SelectList(db.Regimen1, "RegimenID", "RegimenName", exerciseregimen.RegimenID);
            return View(exerciseregimen);
        }

        //
        // GET: /ExerciseRegimen/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ExerciseRegimen exerciseregimen = db.ExerciseRegimen1.Find(id);
            if (exerciseregimen == null)
            {
                return HttpNotFound();
            }
            ViewBag.ExerciseID = new SelectList(db.Exercises, "ExerciseID", "Name", exerciseregimen.ExerciseID);
            ViewBag.RegimenID = new SelectList(db.Regimen1, "RegimenID", "RegimenName", exerciseregimen.RegimenID);
            return View(exerciseregimen);
        }

        //
        // POST: /ExerciseRegimen/Edit/5

        [HttpPost]
        public ActionResult Edit(ExerciseRegimen exerciseregimen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exerciseregimen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ExerciseID = new SelectList(db.Exercises, "ExerciseID", "Name", exerciseregimen.ExerciseID);
            ViewBag.RegimenID = new SelectList(db.Regimen1, "RegimenID", "RegimenName", exerciseregimen.RegimenID);
            return View(exerciseregimen);
        }

        //
        // GET: /ExerciseRegimen/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ExerciseRegimen exerciseregimen = db.ExerciseRegimen1.Find(id);
            if (exerciseregimen == null)
            {
                return HttpNotFound();
            }
            return View(exerciseregimen);
        }

        //
        // POST: /ExerciseRegimen/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            ExerciseRegimen exerciseregimen = db.ExerciseRegimen1.Find(id);
            db.ExerciseRegimen1.Remove(exerciseregimen);
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