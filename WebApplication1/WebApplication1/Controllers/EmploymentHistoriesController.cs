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
    public class EmploymentHistoriesController : Controller
    {
        private DataBankEntities db = new DataBankEntities();

        // GET: EmploymentHistories
        public ActionResult Index()
        {
            var employmentHistory = db.EmploymentHistory.Include(e => e.CV);
            return View(employmentHistory.ToList());
        }

        // GET: EmploymentHistories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmploymentHistory employmentHistory = db.EmploymentHistory.Find(id);
            if (employmentHistory == null)
            {
                return HttpNotFound();
            }
            return View(employmentHistory);
        }

        // GET: EmploymentHistories/Create
        public ActionResult Create()
        {
            ViewBag.CV_ID = new SelectList(db.CV, "CV_ID", "DriversLicense");
            return View();
        }

        // POST: EmploymentHistories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmploymentHistory_ID,CV_ID,PlaceOfWork,Role,Description,StartDate,EndDate")] EmploymentHistory employmentHistory)
        {
            if (ModelState.IsValid)
            {
                db.EmploymentHistory.Add(employmentHistory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CV_ID = new SelectList(db.CV, "CV_ID", "DriversLicense", employmentHistory.CV_ID);
            return View(employmentHistory);
        }

        // GET: EmploymentHistories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmploymentHistory employmentHistory = db.EmploymentHistory.Find(id);
            if (employmentHistory == null)
            {
                return HttpNotFound();
            }
            ViewBag.CV_ID = new SelectList(db.CV, "CV_ID", "DriversLicense", employmentHistory.CV_ID);
            return View(employmentHistory);
        }

        // POST: EmploymentHistories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmploymentHistory_ID,CV_ID,PlaceOfWork,Role,Description,StartDate,EndDate")] EmploymentHistory employmentHistory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employmentHistory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CV_ID = new SelectList(db.CV, "CV_ID", "DriversLicense", employmentHistory.CV_ID);
            return View(employmentHistory);
        }

        // GET: EmploymentHistories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmploymentHistory employmentHistory = db.EmploymentHistory.Find(id);
            if (employmentHistory == null)
            {
                return HttpNotFound();
            }
            return View(employmentHistory);
        }

        // POST: EmploymentHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmploymentHistory employmentHistory = db.EmploymentHistory.Find(id);
            db.EmploymentHistory.Remove(employmentHistory);
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
