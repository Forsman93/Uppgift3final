using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Models
{
    public class EducationCVOPs
    {
        public List<EducationVM> EducationVMList()
        {
            DataBankEntities vmdb = new DataBankEntities();
            List<EducationVM> educationVMList = new List<EducationVM>();

            var educationlist = (from edu in vmdb.Education
                                  join cv in vmdb.CV on edu.CV_ID equals
                                  cv.CV_ID
                                  select new
                                  {
                                      edu.SchoolName,
                                      edu.Subject,
                                      edu.Degree,
                                      edu.StartDate,
                                      edu.EndDate,
                                      cv.CV_ID
                                  }).ToList();

            foreach (var item in educationlist)
            {
                EducationVM objcvm = new EducationVM();
                objcvm.SchoolName = item.SchoolName;
                objcvm.Subject = item.Subject;
                objcvm.Degree = item.Degree;
                objcvm.StartDate = item.StartDate;
                objcvm.EndDate = item.EndDate;
                objcvm.Freelancer_ID = item.CV_ID;
                educationVMList.Add(objcvm);
            }

            return educationVMList;

        }


    }
}