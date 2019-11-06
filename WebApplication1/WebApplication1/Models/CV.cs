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
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations;

    public partial class CV
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CV()
        {
            this.Education = new HashSet<Education>();
            this.EmploymentHistory = new HashSet<EmploymentHistory>();
            this.Knowledge = new HashSet<Knowledge>();
        }
    
        public int CV_ID { get; set; }
        public int Freelancer_ID { get; set; }
        [StringLength(55)]
        [Display(Name = "K�rkort")]
        public string DriversLicense { get; set; }
        [StringLength(55)]
        [Display(Name = "Nationalitet")]
        public string Nationality { get; set; }
        [StringLength(55)]
        [Display(Name = "F�delseort")]
        public string CityOfBirth { get; set; }
        [StringLength(500)]
        [Display(Name = "Profil")]
        public string Profile { get; set; }
        [StringLength(500)]
        [Display(Name = "K�rnf�rm�gor")]
        public string CoreAbilities { get; set; }
        [StringLength(500)]
        [Display(Name = "L�nk till din professionella profil")]
        public string MediaLinks { get; set; }
    
        public virtual Freelancer Freelancer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Education> Education { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmploymentHistory> EmploymentHistory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Knowledge> Knowledge { get; set; }
    }

    public class CVDBcontext : DbContext
    {
        public DbSet<CV> CVs { get; set; }
    }
}
