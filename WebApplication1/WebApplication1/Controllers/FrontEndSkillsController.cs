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
    public class FrontEndSkillsController : Controller
    {
        private DataBankEntities db = new DataBankEntities();

        // GET: FrontEndSkills
        public ActionResult Index()
        {
            var frontEndSkills = db.FrontEndSkills.Include(f => f.Knowledge);
            return View(frontEndSkills.ToList());
        }

        // GET: FrontEndSkills/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FrontEndSkills frontEndSkills = db.FrontEndSkills.Find(id);
            if (frontEndSkills == null)
            {
                return HttpNotFound();
            }
            return View(frontEndSkills);
        }

        // GET: FrontEndSkills/Create
        public ActionResult Create()
        {
            ViewBag.Knowledge_ID = new SelectList(db.Knowledge, "Knowledge_ID", "Knowledge_ID");
            return View();
        }

        // POST: FrontEndSkills/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FrontEnd_ID,Knowledge_ID,HTML,CSS,Jscript")] FrontEndSkills frontEndSkills)
        {
            if (ModelState.IsValid)
            {
                db.FrontEndSkills.Add(frontEndSkills);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Knowledge_ID = new SelectList(db.Knowledge, "Knowledge_ID", "Knowledge_ID", frontEndSkills.Knowledge_ID);
            return View(frontEndSkills);
        }

        // GET: FrontEndSkills/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FrontEndSkills frontEndSkills = db.FrontEndSkills.Find(id);
            if (frontEndSkills == null)
            {
                return HttpNotFound();
            }
            ViewBag.Knowledge_ID = new SelectList(db.Knowledge, "Knowledge_ID", "Knowledge_ID", frontEndSkills.Knowledge_ID);
            return View(frontEndSkills);
        }

        // POST: FrontEndSkills/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FrontEnd_ID,Knowledge_ID,HTML,CSS,Jscript")] FrontEndSkills frontEndSkills)
        {
            if (ModelState.IsValid)
            {
                db.Entry(frontEndSkills).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("/Details/2", "Knowledges");
            }
            ViewBag.Knowledge_ID = new SelectList(db.Knowledge, "Knowledge_ID", "Knowledge_ID", frontEndSkills.Knowledge_ID);
            return View(frontEndSkills);
        }

        // GET: FrontEndSkills/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FrontEndSkills frontEndSkills = db.FrontEndSkills.Find(id);
            if (frontEndSkills == null)
            {
                return HttpNotFound();
            }
            return View(frontEndSkills);
        }

        // POST: FrontEndSkills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FrontEndSkills frontEndSkills = db.FrontEndSkills.Find(id);
            db.FrontEndSkills.Remove(frontEndSkills);
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
