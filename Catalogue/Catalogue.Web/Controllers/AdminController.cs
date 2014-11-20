using Catalogue.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Catalogue.Web.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private CatalogueContext db;

        public AdminController(CatalogueContext db)
        {
            this.db = db;
        }

        public ActionResult CustomersList()
        {
            var customers = db.Users.ToList();

            return View(customers);
        }

        public ActionResult ProductsList()
        {
            var products = db.Products.ToList();

            return View(products);
        }

        public ActionResult CustomerEdit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: /Test/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CustomerEdit(User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("CustomersList");
            }
            return View(user);
        }

        // GET: /Test/Delete/5
        public ActionResult CustomerDelete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: /Test/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult CustomerDeleteConfirmed(string id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("CustomersList");
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