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
    public class CategoryController : Controller
    {
        private ICategoryService categoryServices;

        public CategoryController(ICategoryService categoryServices)
        {
            this.categoryServices = categoryServices;
        }

        public ActionResult Index(int? page)
        {
            var pageItems = categoryServices.GetItems(page);

            var categoryListViewModel = new CategoryListViewModel()
            {
                Categories = pageItems.Items.ToList(),
                Count = pageItems.PageCount,
                Page = pageItems.CurrentPage
            };

            return View(categoryListViewModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var category = new Category()
                {
                    CategoryID = model.CategoryID,
                    Name = model.Name
                };

                categoryServices.Add(category);

                return RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult LoadCategories()
        {
            List<SelectListItem> categoriesList = new List<SelectListItem>();

            var categories = categoryServices.GetAll();

            foreach (var item in categories)
            {
                categoriesList.Add(new SelectListItem { Text = item.Name, Value = item.CategoryID.ToString() });
            }

            ViewData["categories"] = categoriesList;

            return PartialView("_CategoriesPartial");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = categoryServices.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }

            var model = new CategoryViewModel()
            {
                CategoryID = category.CategoryID,
                Name = category.Name
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var category = new Category()
                {
                    CategoryID = model.CategoryID,
                    Name = model.Name
                };

                categoryServices.Modify(category);

                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: /Category/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = categoryServices.Find(id);

            if (category == null)
            {
                return HttpNotFound();
            }

            var model = new CategoryViewModel()
            {
                CategoryID = category.CategoryID,
                Name = category.Name
            };
            return View(model);
        }

        // POST: /Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = categoryServices.Find(id);

            categoryServices.Remove(category);

            return RedirectToAction("Index");
        }
    }
}
