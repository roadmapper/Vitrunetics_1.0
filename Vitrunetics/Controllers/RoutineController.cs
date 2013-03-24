using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vitrunetics.Controllers
{
    public class RoutineController : Controller
    {
        private VitruneticsContext db = new VitruneticsContext();

        //
        // GET: /Routine/

        public ActionResult Index()
        {
            return View(db.Regimen1.ToList());
        }

        //
        // GET: /Routine/Details/5

        public ActionResult Details(int id = 0)
        {
            Regimen regimen = db.Regimen1.Find(id);
            if (regimen == null)
            {
                return HttpNotFound();
            }
            return View(regimen);
        }

        //
        // GET: /Routine/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Routine/Create

        [HttpPost]
        public ActionResult Create(Regimen regimen)
        {
            if (ModelState.IsValid)
            {
                db.Regimen1.Add(regimen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(regimen);
        }

        //
        // GET: /Routine/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Regimen regimen = db.Regimen1.Find(id);
            if (regimen == null)
            {
                return HttpNotFound();
            }
            return View(regimen);
        }

        //
        // POST: /Routine/Edit/5

        [HttpPost]
        public ActionResult Edit(Regimen regimen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(regimen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(regimen);
        }

        //
        // GET: /Routine/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Regimen regimen = db.Regimen1.Find(id);
            if (regimen == null)
            {
                return HttpNotFound();
            }
            return View(regimen);
        }

        //
        // POST: /Routine/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Regimen regimen = db.Regimen1.Find(id);
            db.Regimen1.Remove(regimen);
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