using Catalogue.Models.Services;
using Catalogue.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Catalogue.Web.Controllers
{
    public class ProductController : Controller
    {
        private IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        // GET: Product
        public ViewResult List()
        {
            return View(productService.GetAt(1));
        }
    }
}