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
        private CatalogueContext db;

        public AddProductController(CatalogueContext db)
        {
            this.db = db;
        }

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
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Save(ProductViewModel model, Image img)
        {
            if (ModelState.IsValid)
            {
                RenderImage service = new RenderImage();
                service.RenderImg(img, model.postedFile);
                var rndrResizedImage = service.ResizeFile(img);

                var images = new List<Image>();
                images.Add(rndrResizedImage);

                var product = new Product()
                {
                    Category = model.Category,
                    CategoryID = model.CategoryID,
                    Description = model.Description,
                    Manufacturers = model.Manufacturers,
                    Name = model.Name,
                    ProductYear = model.ProductYear,
                    Images = images
                };

                db.Products.Add(product);
                db.SaveChanges();
            }

            return View();
        }

        public ActionResult SaveUploadedFile()
        {
            bool isSavedSuccessfully = true;
            string fName = "";
            try
            {
                foreach (string fileName in Request.Files)
                {
                    HttpPostedFileBase file = Request.Files[fileName];
                    //Save file content goes here
                    fName = file.FileName;
                    if (file != null && file.ContentLength > 0)
                    {
                        RenderImage services = new RenderImage();
                        var imgBytes = services.ConverToBytes(file);
                        var image = new Image()
                        {
                            ProductID = 1,
                            ImageName = fName,
                            Value = imgBytes
                        };
                        db.Images.Add(image);
                        db.SaveChanges();
                    }

                }

            }
            catch (Exception)
            {
                isSavedSuccessfully = false;
            }


            if (isSavedSuccessfully)
            {
                return Json(new { Message = fName });
            }
            else
            {
                return Json(new { Message = "Error in saving file" });
            }
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