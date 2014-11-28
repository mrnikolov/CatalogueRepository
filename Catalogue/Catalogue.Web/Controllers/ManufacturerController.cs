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
        private IManufacturerService manufacturerServices;

        public ManufacturerController(IManufacturerService manufacturerServices)
        {
            this.manufacturerServices = manufacturerServices;
        }

        public ActionResult Index(int? page)
        {
            var pageItems = manufacturerServices.GetItems(page);

            var manufacturerListViewModel = new ManufacturerListViewModel()
            {
                Manufacturers = pageItems.Items.ToList(),
                Count = pageItems.PageCount,
                Page = pageItems.CurrentPage
            };

            return View(manufacturerListViewModel);
        }

        public ActionResult Create()
        {
            return View();
        }

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

                manufacturerServices.Add(manufacturer);

                return RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult LoadManufacturers()
        {
            List<SelectListItem> manufacturersList = new List<SelectListItem>();

            var manufacturers = manufacturerServices.GetAll();

            foreach (var item in manufacturers)
            {
                manufacturersList.Add(new SelectListItem { Text = item.Name, Value = item.ManufacturerID.ToString() });
            }

            ViewData["manufacturers"] = manufacturersList;

            return PartialView("_ManufacturersPartial");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var manufacturer = manufacturerServices.Find(id);

            if (manufacturer == null)
            {
                return HttpNotFound();
            }

            var model = new ManufacturerViewModel()
            {
                ManufacturerID = manufacturer.ManufacturerID,
                Name = manufacturer.Name,
                Description = manufacturer.Description
            };

            return View(model);
        }

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

                manufacturerServices.Modify(manufacturer);

                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var manufacturer = manufacturerServices.Find(id);

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

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var manufacturer = manufacturerServices.Find(id);
            manufacturerServices.Remove(manufacturer);

            return RedirectToAction("Index");
        }
    }
}
