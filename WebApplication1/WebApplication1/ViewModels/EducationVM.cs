using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.ViewModels
{
    public class EducationVM
    {
        public int Freelancer_ID { get; set; }
        public string SchoolName { get; set; }
        public string Subject { get; set; }
        public string Degree { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}