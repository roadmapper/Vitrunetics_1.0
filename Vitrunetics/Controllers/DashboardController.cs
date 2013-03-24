using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using Vitrunetics.Models;

namespace Vitrunetics.Controllers
{
    public class DashboardController : BootstrapBaseController
    {
        //private static List<Patient> _models = ModelIntializer.CreatePatients();
        //private static List<Exercise> _models2 = ModelIntializer2.CreateExercises();
        
        [Authorize]
        public ActionResult Dashboard()
        {
            var entities = new VitruneticsContext();
           return View(entities.Patients.ToList());
        }

        [HttpPost]
        public ActionResult Create(Patient model)
        {
            try
            {
                using (var db = new VitruneticsContext())
                {
                    db.Patients.Add(model);
                    db.SaveChanges();
                }
                //Success("Your information was saved!");
                return RedirectToAction("Dashboard");
            }
            catch
            {
                Error("there were some errors in your form.");
                return View(model);
            }
            
            //if (ModelState.IsValid)
            //{
            //    //model.Id = _models.Count == 0 ? 1 : _models.Select(x => x.Id).Max() + 1;
            //    //_models.Add(model);
            //    var db = new VitruneticsContext();
            //    db.Patients.Add(model);
            //    Success("Your information was saved!");
            //    return RedirectToAction("Dashboard");
            //}
            //Error("there were some errors in your form.");
            //return View(model);
        }

        public ActionResult Create()
        {
            return View(new Patient());
        }

        //public ActionResult CreateExercise()
        //{
        //    return View(new Exercise());
        //}


        public ActionResult Delete(int id)
        {
            //_models.Remove(_models.Get(id));
            var db = new VitruneticsContext();
            db.Patients.Remove(db.Patients.Find(id));
            db.SaveChanges();
            //Information("Patient deleted.");
            if (db.Patients.Count() == 0)
            {
                Attention("You have deleted all the patients! Create a new one to continue the demo.");
            }
            return RedirectToAction("Dashboard");
        }


        public ActionResult Edit(int id)
        {
            using (var db = new VitruneticsContext())
            {
                return View("Create", db.Patients.Find(id));
            }
            /*var model = db.Patients.Single(x => x.PatientID == id);
            return View("Create", model);*/
        }
        
        [HttpPost]
        public ActionResult Edit(Patient model, int id)
        {
            //if (ModelState.IsValid)
            //{
            //    /*_models.Remove(_models.Get(id));
            //    model.Id = id;
            //    _models.Add(model);*/
            //    Success("The model was updated!");
            //    return RedirectToAction("Dashboard");
            //}
            //return View("Create", model);
            bool saveFailed;
            var db = new VitruneticsContext();
            try
            {
                model.PatientID = id;
                db.Entry(model).State = System.Data.EntityState.Modified;
                //db.Entry(model).Reload();
                db.SaveChanges();
                saveFailed = false;
                //Success("Your information was saved!");
                return RedirectToAction("Dashboard");
            }
            catch (DbUpdateConcurrencyException ex)
            {
                //saveFailed = true;
                //// reload database values and try again
                //foreach (DbEntityEntry entry in exception.Entries)
                //{
                //    // entry.OriginalValues.SetValues(entry.GetDatabaseValues());

                //    // workaround
                //    var currentValues = entry.CurrentValues.Clone();
                //    entry.Reload();
                //    entry.CurrentValues.SetValues(currentValues);
                //}
                ////Error("there were some errors in your form.");
                ////return View();

                var entry = ex.Entries.Single();
                var currentValues = entry.CurrentValues.Clone();
                entry.Reload();
                entry.CurrentValues.SetValues(currentValues);
                var clientValues = (Patient)entry.Entity;
                var databaseValues = (Patient)entry.OriginalValues.ToObject();


                //Success("Your information was saved!");
                return RedirectToAction("Dashboard");
            }
            
        }

        public ActionResult Details(int id)
        {
            using (var db = new VitruneticsContext())
            {
                return View(db.Patients.Find(id));
            }
            //return View(model);
        }

        public ActionResult ViewRegimen(int id)
        {
            //SqlConnection connection;
            
            //   connection = new SqlConnection("Server=tcp:zt0u9ybydt.database.windows.net,1433;Database=VitruneticsUsers;User ID=vitrunetics@zt0u9ybydt;Password=KinectPT1;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;");
            //   SqlCommand command = new SqlCommand("SELECT * FROM Patient INNER JOIN PatientRegimen ON Patient.PatientID=PatientRegimen.PatientID INNER JOIN Regimen ON Regimen.RegimenID=PatientRegimen.RegimenID INNER JOIN ExerciseRegimen ON ExerciseRegimen.RegimenID=Regimen.RegimenID INNER JOIN Exercise ON Exercise.ExerciseID=ExerciseRegimen.ExerciseID INNER JOIN ExerciseSequence ON ExerciseSequence.ExerciseID=Exercise.ExerciseID INNER JOIN ExerciseStep ON ExerciseStep.ExerciseSequenceID=ExerciseSequence.ExerciseSequenceID INNER JOIN Joint ON Joint.ExerciseStepID=ExerciseStep.ExerciseStepID", connection);

            //   connection.Open();
            //   SqlDataReader reader = command.ExecuteReader(); 
            //   // Create a DataTable object to hold all the data returned by the query.
            //   DataTable dataTable = new DataTable();
            //    // Use the DataTable.Load(SqlDataReader) function to put the results of the query into a DataTable.
            //    dataTable.Load(reader);
            //    String columns = string.Empty;
            //    foreach (DataColumn column in dataTable.Columns)
            //    {
            //        columns += column.ColumnName + " | ";
            //    }
            //    int topRows = 10;
                
            //    for (int i = 0; i < topRows; i++)
            //    {
            //        String rowText = string.Empty;
            //        foreach (DataColumn column in dataTable.Columns)
            //        {
            //            rowText += dataTable.Rows[i][column.ColumnName] + " | ";
            //        }
            //        //Console.WriteLine(rowText);
            //    }
            //    connection.Close();
            
            
            
 
            

            //SELECT * FROM Patient INNER JOIN PatientRegimen ON Patient.PatientID=PatientRegimen.PatientID INNER JOIN Regimen ON Regimen.RegimenID=PatientRegimen.RegimenID INNER JOIN ExerciseRegimen ON ExerciseRegimen.RegimenID=Regimen.RegimenID INNER JOIN Exercise ON Exercise.ExerciseID=ExerciseRegimen.ExerciseID INNER JOIN ExerciseSequence ON ExerciseSequence.ExerciseID=Exercise.ExerciseID INNER JOIN ExerciseStep ON ExerciseStep.ExerciseSequenceID=ExerciseSequence.ExerciseSequenceID INNER JOIN Joint ON Joint.ExerciseStepID=ExerciseStep.ExerciseStepID
            using (var db = new VitruneticsContext())
            {
                //var blogs = db.Database.SqlQuery<string>("SELECT * FROM Patient INNER JOIN PatientRegimen ON Patient.PatientID=PatientRegimen.PatientID INNER JOIN Regimen ON Regimen.RegimenID=PatientRegimen.RegimenID INNER JOIN ExerciseRegimen ON ExerciseRegimen.RegimenID=Regimen.RegimenID INNER JOIN Exercise ON Exercise.ExerciseID=ExerciseRegimen.ExerciseID INNER JOIN ExerciseSequence ON ExerciseSequence.ExerciseID=Exercise.ExerciseID INNER JOIN ExerciseStep ON ExerciseStep.ExerciseSequenceID=ExerciseSequence.ExerciseSequenceID INNER JOIN Joint ON Joint.ExerciseStepID=ExerciseStep.ExerciseStepID").ToList();
                return View(blogs);
            }
        }

        //public ActionResult DetailsExercise(int id)
        //{
        //    var model = _models2.Get(id);
        //    return View(model);
        //}

        ///*public FileStreamResult GenerateXml(int id)
        //{
        //    /*var model = _models2.Get(id);
        //    XmlDocument doc = new XmlDocument();
        //    doc.LoadXml("<exercise>" + model.Name + "</exercise>"); //Your string here
        //    //FileStream f = new FileStream("exercise" + id + ".xml", FileMode.Create);

        //    // Save the document to a file and auto-indent the output.
        //    XmlTextWriter writer = new XmlTextWriter(f, null);
        //    writer.Formatting = Formatting.Indented;
        //    doc.Save(writer);
        //    var fileStreamResult = File(f, "application/xml");
        //    return fileStreamResult;*/
            


        //    /*string xml = "<exercise>" + model.Name + "</exercise>"; //string presented xml
        //    var stream = new MemoryStream();
        //    var writer = XmlWriter.Create(stream);
        //    writer.WriteRaw(xml);
        //    stream.Position = 0;
        //    var fileStreamResult = File(stream, "application/xml");
        //    return fileStreamResult;*/

            
        ////}

    }
}
