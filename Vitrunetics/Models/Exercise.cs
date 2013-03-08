using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Vitrunetics.Models
{
    public class Exercise
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        public int Sets { get; set; }

        public int Reps { get; set; }

        public int HoldTime { get; set; }

        [DataType(DataType.Text)]
        public string Comments { get; set; }

    }

    public static class ModelIntializer2
    {
        public static List<Exercise> CreateExercises()
        {
            return new List<Exercise>
                       {
                           new Exercise
                               {
                                   Id = 1,
                                   //Blog = "http://foobar.com",
                                   Name = "test",
                                   //Password = "asdfsd",
                                   //DOB = DateTime.Now.AddYears(1)
                               }
                       };
        }
    }

    public static class ModelExtention2
    {
        public static Exercise Get(this List<Exercise> models, int id)
        {
            return models.First(x => x.Id == id);
        }
    }
}