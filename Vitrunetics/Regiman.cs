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
    
    public partial class Regiman
    {
        public Regiman()
        {
            this.ExerciseRegimen = new HashSet<ExerciseRegiman>();
            this.PatientRegimen = new HashSet<PatientRegimen>();
        }
    
        public int RegimenID { get; set; }
        public string RegimenName { get; set; }
    
        public virtual ICollection<ExerciseRegiman> ExerciseRegimen { get; set; }
        public virtual ICollection<PatientRegimen> PatientRegimen { get; set; }
    }
}