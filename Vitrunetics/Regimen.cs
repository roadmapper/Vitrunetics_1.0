//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Vitrunetics
{
    using System;
    using System.Collections.Generic;
    
    public partial class Regimen
    {
        public Regimen()
        {
            this.ExerciseRegimen = new HashSet<ExerciseRegimen>();
            this.PatientRegimen = new HashSet<PatientRegimen>();
        }
    
        public int RegimenID { get; set; }
        public string RegimenName { get; set; }
    
        public virtual ICollection<ExerciseRegimen> ExerciseRegimen { get; set; }
        public virtual ICollection<PatientRegimen> PatientRegimen { get; set; }
    }
}
