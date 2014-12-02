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
    public class ProductController : Controller
    {
        private IProductService productServices;

        public ProductController(IProductService productServices)
        {
            this.productServices = productServices;
        }

        public ActionResult ProductsList(int? page)
        {
            var pageItems = productServices.GetItems(page);

            var productListViewModels = new ProductListViewModels()
            {
                Products = pageItems.Items.ToList(),
                Count = pageItems.PageCount,
                Page = pageItems.CurrentPage
            };

            return View(productListViewModels);
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
                var images = new List<Image>();

                foreach (var item in model.Files)
                {
                    if (item != null)
                    {
                        RenderImage service = new RenderImage();
                        service.RenderImg(img, item);
                        var rndrResizedImage = service.ResizeFile(img);
                        images.Add(rndrResizedImage);
                    }

                }

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

                productServices.Add(product);
                return RedirectToAction("ProductsList");
            }
            return View();
        }

        public ActionResult GetYears()
        {
            List<int> years = new List<int>();
            var currentYear = DateTime.Now.Year;
            years.Add(currentYear + 1);

            for (int i = 0; i < 30; i++)
            {
                years.Add(currentYear - i);
            }

            return PartialView("_YearsPartial", years);
        }
    }
}