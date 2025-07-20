using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using UserManagementSystem.Models;

namespace UserManagementSystem.Controllers
{
    public class UsersController : Controller
    {
        private UserDbContext db = new UserDbContext();

        // GET: Users
        public ActionResult Index(string searchName, string searchEmail, string statusFilter, string sortOrder)
        {
            var users = db.Users.AsQueryable();

            if (!string.IsNullOrEmpty(searchName))
                users = users.Where(u => u.Name.Contains(searchName));

            if (!string.IsNullOrEmpty(searchEmail))
                users = users.Where(u => u.Email.Contains(searchEmail));

            if (!string.IsNullOrEmpty(statusFilter))
            {
                if (statusFilter == "Active")
                    users = users.Where(u => u.IsActive);
                else if (statusFilter == "Inactive")
                    users = users.Where(u => !u.IsActive);
            }

            switch (sortOrder)
            {
                case "Age_Asc":
                    users = users.OrderBy(u => u.Age);
                    break;
                case "Age_Desc":
                    users = users.OrderByDescending(u => u.Age);
                    break;
                default:
                    users = users.OrderBy(u => u.Id);
                    break;
            }

            ViewBag.SearchName = searchName;
            ViewBag.SearchEmail = searchEmail;
            ViewBag.StatusFilter = statusFilter;
            ViewBag.SortOrder = sortOrder;

            return View(users.ToList());
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var user = db.Users.Find(id);
            if (user == null) return HttpNotFound();
            return View(user);
        }

        // POST: Users/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var user = db.Users.Find(id);
            if (user == null) return HttpNotFound();
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) db.Dispose();
            base.Dispose(disposing);
        }
    }
}