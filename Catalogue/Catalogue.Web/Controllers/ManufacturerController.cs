using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Catalogue.Models.Entities;
using Catalogue.Models.Services;

namespace Catalogue.Web.Controllers
{
    public class ManufacturerController : Controller
    {
        private IManufacturerService manufacturerService;

        public ManufacturerController(IManufacturerService manufacturerService)
        {
            this.manufacturerService = manufacturerService;
        }

        // GET: /Manufacturer/
        public ActionResult Index()
        {
            return View(manufacturerService.GetAll());
        }

        // GET: /Manufacturer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var manufacturer = manufacturerService.Find(id);

            if (manufacturer == null)
            {
                return HttpNotFound();
            }

            return View(manufacturer);
        }

        // GET: /Manufacturer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Manufacturer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ManufacturerID,Name,Description")] Manufacturer manufacturer)
        {
            if (ModelState.IsValid)
            {
                manufacturerService.Add(manufacturer);

                return RedirectToAction("Index");
            }

            return View(manufacturer);
        }

        // GET: /Manufacturer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var manufacturer = manufacturerService.Find(id);

            if (manufacturer == null)
            {
                return HttpNotFound();
            }

            return View(manufacturer);
        }

        // POST: /Manufacturer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ManufacturerID,Name,Description")] Manufacturer manufacturer)
        {
            if (ModelState.IsValid)
            {
                manufacturerService.Modify(manufacturer);

                return RedirectToAction("Index");
            }

            return View(manufacturer);
        }

        // GET: /Manufacturer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var manufacturer = manufacturerService.Find(id);
            
            if (manufacturer == null)
            {
                return HttpNotFound();
            }

            return View(manufacturer);
        }

        // POST: /Manufacturer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var manufacturer = manufacturerService.Find(id);
            manufacturerService.Remove(manufacturer);

            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
