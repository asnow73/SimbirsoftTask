﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SimbirsoftTask.Models;
using SimbirsoftTask.Models.Repository;

namespace SimbirsoftTask.Controllers
{
    public class RoleController : Controller
    {
        private SqlRepository repo = new SqlRepository();
        //private DataBaseContext db = new DataBaseContext();

        // GET: /Role/
        public ActionResult Index()
        {
            var roles = repo.Roles.ToList();
            return View(roles);
        }

        

        // GET: /Role/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var role = repo.GetRole(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        // GET: /Role/Create
        public ActionResult Create()
        {
            return View();
        }

        
        // POST: /Role/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Name")] Role role)
        {
            if (ModelState.IsValid)
            {
                repo.CreateRole(role);
                return RedirectToAction("Index");
            }

            return View(role);
        }

        
        // GET: /Role/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Role role = repo.GetRole(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }
        
        // POST: /Role/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Name")] Role role)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(role).State = EntityState.Modified;
                //db.SaveChanges();
                repo.UpdateRole(role);
                return RedirectToAction("Index");
            }
            return View(role);
        }

        /*
        // GET: /Role/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Role role = db.Roles.Find(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        // POST: /Role/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Role role = db.Roles.Find(id);
            db.Roles.Remove(role);
            db.SaveChanges();
            return RedirectToAction("Index");
        }*/

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repo.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
