using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class EducationDetailsController : Controller
    {
        // GET: EducationDetails
        public ActionResult Index()
        {
            EducationCVOPs ecop = new EducationCVOPs();

            return View(ecop.EducationVMList());
        }
    }
}