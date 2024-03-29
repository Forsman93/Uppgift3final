//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Languages
    {
        public int Languages_ID { get; set; }
        public int Knowledge_ID { get; set; }
        [Range(0, 100)]
        [Display(Name = "Svenska (%)")]
        public Nullable<double> Swedish { get; set; }
        [Range(0, 100)]
        [Display(Name = "Engelska (%)")]
        public Nullable<double> English { get; set; }
        [Range(0, 100)]
        [Display(Name = "Tyska (%)")]
        public double German { get; set; }
        [Range(0, 100)]
        [Display(Name = "Spanska (%)")]
        public Nullable<double> Spanish { get; set; }
        [StringLength(55)]
        [Display(Name = "Annat? Skriv h�r!")]
        public string Other { get; set; }
    
        public virtual Knowledge Knowledge { get; set; }
    }
}
