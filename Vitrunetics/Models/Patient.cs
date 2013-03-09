using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vitrunetics.Models
{
    public class Patient
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        /*[DataType(DataType.Url)]
        public string Blog { get; set; }*/

        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Text)]
        public string Gender { get; set; }

        [DataType(DataType.Text)]
        public string Reason { get; set; }

        /*[
        public List<Exercise> Regimen { get; set; }*/

        /*[DataType(DataType.Password)]
        public string Password { get; set; }*/
    }

    public static class ModelIntializer
    {
        public static List<Patient> CreatePatients()
        {
            return new List<Patient>
                       {
                           new Patient
                               {
                                   Id = 1,
                                   //Blog = "http://foobar.com",
                                   Name = "asdf",
                                   //Password = "asdfsd",
                                   DOB = DateTime.Now.AddYears(1)
                               },
                           new Patient
                               {
                                   Id = 2,
                                   //Blog = "http://foobar.com",
                                   
                                   Name = "Jonathon",
                                   Email =  "j@virginia.edu",
                                   Gender = "Male",
                                   Reason = "N/A",
                                   //Password = "dddddddasdfsd",
                                   DOB = DateTime.Now.AddYears(2)
                               },
                       };
        }
    }

    public static class ModelExtention
    {
        public static Patient Get(this List<Patient> models, int id)
        {
            return models.First(x => x.Id == id);
        }
    }
}