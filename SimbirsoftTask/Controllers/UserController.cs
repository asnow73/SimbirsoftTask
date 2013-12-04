using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SimbirsoftTask.Models;
using SimbirsoftTask.Models.Repository;

using System.Web.Security;
using SimbirsoftTask.Providers;

namespace SimbirsoftTask.Controllers
{
    public class UserController : Controller
    {
        //private DataBaseContext db = new DataBaseContext();
        private SqlRepository repo = new SqlRepository();

        // GET: /User/
        public ActionResult Index()
        {
            var users = repo.Users.ToList();
            return View(users);
        }
        
        // GET: /User/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var user = repo.GetUser(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: /User/Create
        public ActionResult Create()
        {
            // Формируем список команд для передачи в представление
            SelectList roles = new SelectList(repo.Roles, "Id", "Name");
            ViewBag.Roles = roles;
            return View();
            //ViewBag.RoleFieldVisible = true;
            //return View("~/Views/User/Create.cshtml");
        }

        // POST: /User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Email,Password,Name,Surname,Birthday,RoleId")] User user)
        {           
            if (ModelState.IsValid)
            {
                repo.CreateUser(user);
                return RedirectToAction("Index");
            }

            return View(user);
        }

        
        // GET: /User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            User user = repo.GetUser(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            SelectList roles = new SelectList(repo.Roles, "Id", "Name", user.RoleId);
            ViewBag.Roles = roles;
            return View(user);
        }
        
        // POST: /User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Email,Password,Name,Surname,Birthday,RoleId")] User user)
        {
            if (ModelState.IsValid)
            {
                repo.UpdateUser(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: /User/Delete/5
        public ActionResult Delete(int? id)
        {           
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = repo.GetUser(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: /User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            repo.RemoveUser(id);
            return RedirectToAction("Index");
        }

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
