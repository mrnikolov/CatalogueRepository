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
using Catalogue.Web.Models;

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

            var model = new ManufacturerViewModel()
            {
                 Name = manufacturer.Name,
                  Description = manufacturer.Description
            };

            return View(model);
        }

        // GET: /Manufacturer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Manufacturer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ManufacturerViewModel model)
        {
            if (ModelState.IsValid)
            {
                var manufacturer = new Manufacturer()
                {
                    ManufacturerID = model.ManufacturerID,
                    Name = model.Name,
                    Description = model.Description
                };

                manufacturerService.Add(manufacturer);

                return RedirectToAction("Index");
            }

            return View(model);
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

            var model = new ManufacturerViewModel()
            {
                Name = manufacturer.Name,
                Description = manufacturer.Description
            };

            return View(model);
        }

        // POST: /Manufacturer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ManufacturerViewModel model)
        {
            if (ModelState.IsValid)
            {
                var manufacturer = new Manufacturer()
                {
                    ManufacturerID = model.ManufacturerID,
                    Name = model.Name,
                    Description = model.Description
                };

                manufacturerService.Modify(manufacturer);

                return RedirectToAction("Index");
            }
            return View(model);
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

            var model = new ManufacturerViewModel()
            {
                Name = manufacturer.Name,
                Description = manufacturer.Description
            };

            return View(model);
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
    }
}
