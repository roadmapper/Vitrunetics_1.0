using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vitrunetics.Controllers
{
    public class ExerciseStepController : Controller
    {
        private VitruneticsContext db = new VitruneticsContext();

        //
        // GET: /ExerciseStep/

        public ActionResult Index()
        {
            var exercisesteps = db.ExerciseSteps.Include(e => e.ExerciseSequence);
            return View(exercisesteps.ToList());
        }

        //
        // GET: /ExerciseStep/Details/5

        public ActionResult Details(int id = 0)
        {
            ExerciseStep exercisestep = db.ExerciseSteps.Find(id);
            if (exercisestep == null)
            {
                return HttpNotFound();
            }
            return View(exercisestep);
        }

        //
        // GET: /ExerciseStep/Create

        public ActionResult Create()
        {
            ViewBag.ExerciseSequenceID = new SelectList(db.ExerciseSequences, "ExerciseSequenceID", "ExerciseSequenceID");
            return View();
        }

        //
        // POST: /ExerciseStep/Create

        [HttpPost]
        public ActionResult Create(ExerciseStep exercisestep)
        {
            if (ModelState.IsValid)
            {
                db.ExerciseSteps.Add(exercisestep);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ExerciseSequenceID = new SelectList(db.ExerciseSequences, "ExerciseSequenceID", "ExerciseSequenceID", exercisestep.ExerciseSequenceID);
            return View(exercisestep);
        }

        //
        // GET: /ExerciseStep/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ExerciseStep exercisestep = db.ExerciseSteps.Find(id);
            if (exercisestep == null)
            {
                return HttpNotFound();
            }
            ViewBag.ExerciseSequenceID = new SelectList(db.ExerciseSequences, "ExerciseSequenceID", "ExerciseSequenceID", exercisestep.ExerciseSequenceID);
            return View(exercisestep);
        }

        //
        // POST: /ExerciseStep/Edit/5

        [HttpPost]
        public ActionResult Edit(ExerciseStep exercisestep)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exercisestep).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ExerciseSequenceID = new SelectList(db.ExerciseSequences, "ExerciseSequenceID", "ExerciseSequenceID", exercisestep.ExerciseSequenceID);
            return View(exercisestep);
        }

        //
        // GET: /ExerciseStep/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ExerciseStep exercisestep = db.ExerciseSteps.Find(id);
            if (exercisestep == null)
            {
                return HttpNotFound();
            }
            return View(exercisestep);
        }

        //
        // POST: /ExerciseStep/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            ExerciseStep exercisestep = db.ExerciseSteps.Find(id);
            db.ExerciseSteps.Remove(exercisestep);
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