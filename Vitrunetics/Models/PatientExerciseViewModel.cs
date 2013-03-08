using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vitrunetics.Models
{
    public class PatientExerciseViewModel
    {
        public List<Patient> PatientData { get; set; }
        public List<Exercise> ExerciseData { get; set; }

    }
}