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
    
    public partial class EmploymentHistory
    {
        public int EmploymentHistory_ID { get; set; }
        public int CV_ID { get; set; }
        public string PlaceOfWork { get; set; }
        public string Role { get; set; }
        public string Description { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    
        public virtual CV CV { get; set; }
    }
}
