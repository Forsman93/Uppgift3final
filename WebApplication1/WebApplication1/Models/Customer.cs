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
    
    public partial class Customer
    {
        public int Customer_ID { get; set; }
        public int PersonalInformation_ID { get; set; }
    
        public virtual PersonalInformation PersonalInformation { get; set; }
    }
}
