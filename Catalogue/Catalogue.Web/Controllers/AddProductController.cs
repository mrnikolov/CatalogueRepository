using Catalogue.Models.Entities;
using Catalogue.Models.Services;
using Catalogue.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Catalogue.Web.Controllers
{
    public class AddProductController : Controller
    {
        private IManufacturerService manufacturerService;
        private ICategoryService categoryService;

        public AddProductController(IManufacturerService manufacturerService, ICategoryService categoryService)
        {
            this.manufacturerService = manufacturerService;
            this.categoryService = categoryService;
        }

        [HttpGet]
        public ActionResult Save()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Image file, HttpPostedFileBase postedFile, Product product)
        {
            if (ModelState.IsValid)
            {
            }

            return View();
        }

        public ActionResult LoadManufacturers()
        {
            List<SelectListItem> manufacturersList = new List<SelectListItem>();

            var manufacturers = manufacturerService.GetAll();

            foreach (var item in manufacturers)
            {
                manufacturersList.Add(new SelectListItem { Text = item.Name, Value = item.ManufacturerID.ToString() });
            }

            ViewData["manufacturers"] = manufacturersList;

            return PartialView("_ManufacturersPartial");
        }

        public ActionResult LoadCategories()
        {
            List<SelectListItem> categoriesList = new List<SelectListItem>();

            var categories = categoryService.GetAll();

            foreach (var item in categories)
            {
                categoriesList.Add(new SelectListItem { Text = item.Name, Value = item.CategoryID.ToString() });
            }

            ViewData["categories"] = categoriesList;

            return PartialView("_CategoriesPartial");
        }
    }
}