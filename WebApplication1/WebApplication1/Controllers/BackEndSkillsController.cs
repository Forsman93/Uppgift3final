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
    public class BackEndSkillsController : Controller
    {
        private DataBankEntities db = new DataBankEntities();

        // GET: BackEndSkills
        public ActionResult Index()
        {
            var backEndSkills = db.BackEndSkills.Include(b => b.Knowledge);
            return View(backEndSkills.ToList());
        }

        // GET: BackEndSkills/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BackEndSkills backEndSkills = db.BackEndSkills.Find(id);
            if (backEndSkills == null)
            {
                return HttpNotFound();
            }
            return View(backEndSkills);
        }

        // GET: BackEndSkills/Create
        public ActionResult Create()
        {
            ViewBag.Knowledge_ID = new SelectList(db.Knowledge, "Knowledge_ID", "Knowledge_ID");
            return View();
        }

        // POST: BackEndSkills/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BackEnd_ID,Knowledge_ID,C_,C,Java")] BackEndSkills backEndSkills)
        {
            if (ModelState.IsValid)
            {
                db.BackEndSkills.Add(backEndSkills);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Knowledge_ID = new SelectList(db.Knowledge, "Knowledge_ID", "Knowledge_ID", backEndSkills.Knowledge_ID);
            return View(backEndSkills);
        }

        // GET: BackEndSkills/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BackEndSkills backEndSkills = db.BackEndSkills.Find(id);
            if (backEndSkills == null)
            {
                return HttpNotFound();
            }
            ViewBag.Knowledge_ID = new SelectList(db.Knowledge, "Knowledge_ID", "Knowledge_ID", backEndSkills.Knowledge_ID);
            return View(backEndSkills);
        }

        // POST: BackEndSkills/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BackEnd_ID,Knowledge_ID,C_,C,Java")] BackEndSkills backEndSkills)
        {
            if (ModelState.IsValid)
            {
                db.Entry(backEndSkills).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("/Details/2", "Knowledges");
            }
            ViewBag.Knowledge_ID = new SelectList(db.Knowledge, "Knowledge_ID", "Knowledge_ID", backEndSkills.Knowledge_ID);
            return View(backEndSkills);
        }

        // GET: BackEndSkills/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BackEndSkills backEndSkills = db.BackEndSkills.Find(id);
            if (backEndSkills == null)
            {
                return HttpNotFound();
            }
            return View(backEndSkills);
        }

        // POST: BackEndSkills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BackEndSkills backEndSkills = db.BackEndSkills.Find(id);
            db.BackEndSkills.Remove(backEndSkills);
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
