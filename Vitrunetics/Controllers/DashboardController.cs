using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vitrunetics.Models;

namespace Vitrunetics.Controllers
{
    public class DashboardController : BootstrapBaseController
    {
        private static List<Patient> _models = ModelIntializer.CreatePatients();
        [Authorize]
        public ActionResult Dashboard()
        {

            var patients = _models;
            return View(patients);
        }

        [HttpPost]
        public ActionResult Create(Patient model)
        {
            if (ModelState.IsValid)
            {
                model.Id = _models.Count == 0 ? 1 : _models.Select(x => x.Id).Max() + 1;
                _models.Add(model);
                Success("Your information was saved!");
                return RedirectToAction("Dashboard");
            }
            Error("there were some errors in your form.");
            return View(model);
        }

        public ActionResult Create()
        {
            return View(new Patient());
        }

        public ActionResult Delete(int id)
        {
            _models.Remove(_models.Get(id));
            Information("Patient deleted.");
            if (_models.Count == 0)
            {
                Attention("You have deleted all the patients! Create a new one to continue the demo.");
            }
            return RedirectToAction("Dashboard");
        }
        public ActionResult Edit(int id)
        {
            var model = _models.Get(id);
            return View("Create", model);
        }
        [HttpPost]
        public ActionResult Edit(Patient model, int id)
        {
            if (ModelState.IsValid)
            {
                _models.Remove(_models.Get(id));
                model.Id = id;
                _models.Add(model);
                Success("The model was updated!");
                return RedirectToAction("Dashboard");
            }
            return View("Create", model);
        }

        public ActionResult Details(int id)
        {
            var model = _models.Get(id);
            return View(model);
        }

    }
}
