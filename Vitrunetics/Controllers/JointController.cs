using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vitrunetics.Controllers
{
    public class JointController : Controller
    {
        private VitruneticsContext db = new VitruneticsContext();

        //
        // GET: /Joint/

        public ActionResult Index()
        {
            var joints = db.Joints.Include(j => j.ExerciseStep);
            return View(joints.ToList());
        }

        //
        // GET: /Joint/Details/5

        public ActionResult Details(int id = 0)
        {
            Joint joint = db.Joints.Find(id);
            if (joint == null)
            {
                return HttpNotFound();
            }
            return View(joint);
        }

        //
        // GET: /Joint/Create

        public ActionResult Create()
        {
            ViewBag.ExerciseStepID = new SelectList(db.ExerciseSteps, "ExerciseStepID", "Instructions");
            return View();
        }

        //
        // POST: /Joint/Create

        [HttpPost]
        public ActionResult Create(Joint joint)
        {
            if (ModelState.IsValid)
            {
                db.Joints.Add(joint);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ExerciseStepID = new SelectList(db.ExerciseSteps, "ExerciseStepID", "Instructions", joint.ExerciseStepID);
            return View(joint);
        }

        //
        // GET: /Joint/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Joint joint = db.Joints.Find(id);
            if (joint == null)
            {
                return HttpNotFound();
            }
            ViewBag.ExerciseStepID = new SelectList(db.ExerciseSteps, "ExerciseStepID", "Instructions", joint.ExerciseStepID);
            return View(joint);
        }

        //
        // POST: /Joint/Edit/5

        [HttpPost]
        public ActionResult Edit(Joint joint)
        {
            if (ModelState.IsValid)
            {
                db.Entry(joint).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ExerciseStepID = new SelectList(db.ExerciseSteps, "ExerciseStepID", "Instructions", joint.ExerciseStepID);
            return View(joint);
        }

        //
        // GET: /Joint/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Joint joint = db.Joints.Find(id);
            if (joint == null)
            {
                return HttpNotFound();
            }
            return View(joint);
        }

        //
        // POST: /Joint/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Joint joint = db.Joints.Find(id);
            db.Joints.Remove(joint);
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