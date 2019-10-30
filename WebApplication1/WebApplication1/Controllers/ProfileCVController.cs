﻿using System;
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
    public class ProfileCVController : Controller
    {
        private DataBankEntities db = new DataBankEntities();

        // GET: ProfileCV
        public ActionResult Index()
        {
            return View(db.PersonalInformation.ToList());
        }

        // GET: ProfileCV/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonalInformation personalInformation = db.PersonalInformation.Find(id);
            if (personalInformation == null)
            {
                return HttpNotFound();
            }
            return View(personalInformation);
        }

        // GET: ProfileCV/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProfileCV/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonalInformation_ID,FirstName,LastName,Adress,Telephone,Email,UserGroup")] PersonalInformation personalInformation)
        {
            if (ModelState.IsValid)
            {
                db.PersonalInformation.Add(personalInformation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(personalInformation);
        }

        // GET: ProfileCV/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonalInformation personalInformation = db.PersonalInformation.Find(id);
            if (personalInformation == null)
            {
                return HttpNotFound();
            }
            return View(personalInformation);
        }

        // POST: ProfileCV/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonalInformation_ID,FirstName,LastName,Adress,Telephone,Email,UserGroup")] PersonalInformation personalInformation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personalInformation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("/Details/1", "ProfileCV");
            }
            return View(personalInformation);
        }

        // GET: ProfileCV/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonalInformation personalInformation = db.PersonalInformation.Find(id);
            if (personalInformation == null)
            {
                return HttpNotFound();
            }
            return View(personalInformation);
        }

        // POST: ProfileCV/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PersonalInformation personalInformation = db.PersonalInformation.Find(id);
            db.PersonalInformation.Remove(personalInformation);
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
