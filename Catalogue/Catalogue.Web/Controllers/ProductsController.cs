using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Catalogue.Models.Entities;
using Catalogue.Models.Services;
using Catalogue.Models.Abstract;


namespace Catalogue.Web.Controllers
{
    public class ProductsController : Controller
    {
        private IRepository<EFProductsRepository<Product>> repository;

        public ProductsController(IRepository<EFProductsRepository<Product>> productRepository)
        {
            this.repository = productRepository;
        }

        public ActionResult Index()
        {
            return View(repository.All());
        }
    }
}