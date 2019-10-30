using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CVBodyController : Controller
    {
        private DataBankEntities db = new DataBankEntities();

        // GET: CVBody
        public ActionResult Index()
        {
            var cV = db.CV.Include(c => c.Freelancer);
            return View(cV.ToList());
        }

        // GET: CVBody/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CV cV = db.CV.Find(id);
            if (cV == null)
            {
                return HttpNotFound();
            }
            return View(cV);
        }

        // GET: CVBody/Create
        public ActionResult Create()
        {
            ViewBag.Freelancer_ID = new SelectList(db.Freelancer, "Freelancer_ID", "Freelancer_ID");
            return View();
        }

        // POST: CVBody/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CV_ID,Freelancer_ID,DriversLicense,Nationality,CityOfBirth,Profile,CoreAbilities,MediaLinks")] CV cV)
        {
            if (ModelState.IsValid)
            {
                db.CV.Add(cV);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Freelancer_ID = new SelectList(db.Freelancer, "Freelancer_ID", "Freelancer_ID", cV.Freelancer_ID);
            return View(cV);
        }

        // GET: CVBody/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CV cV = db.CV.Find(id);
            if (cV == null)
            {
                return HttpNotFound();
            }
            ViewBag.Freelancer_ID = new SelectList(db.Freelancer, "Freelancer_ID", "Freelancer_ID", cV.Freelancer_ID);
            return View(cV);
        }

        // POST: CVBody/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CV_ID,Freelancer_ID,DriversLicense,Nationality,CityOfBirth,Profile,CoreAbilities,MediaLinks")] CV cV)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cV).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("/Details/2", "CVBody");
            }
            ViewBag.Freelancer_ID = new SelectList(db.Freelancer, "Freelancer_ID", "Freelancer_ID", cV.Freelancer_ID);
            return View(cV);
        }

        // GET: CVBody/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CV cV = db.CV.Find(id);
            if (cV == null)
            {
                return HttpNotFound();
            }
            return View(cV);
        }

        // POST: CVBody/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CV cV = db.CV.Find(id);
            db.CV.Remove(cV);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
