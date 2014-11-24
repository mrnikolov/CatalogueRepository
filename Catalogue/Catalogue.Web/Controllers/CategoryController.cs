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
        private ICategoryService categoryService;
        const int PageSize = 5;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }


        // GET: /Category/
        public ActionResult Index(int? id)
        {
            int pageNumber = id.GetValueOrDefault(1);

            var categories = categoryService.GetAll();
            var viewModel = categories.OrderBy(x => x.CategoryID).Skip((pageNumber - 1) * PageSize).Take(PageSize);
            
            ViewBag.Pages = Math.Ceiling((double)categories.Count() / PageSize);
            ViewBag.Id = id;
            return View(viewModel);
        }

        // GET: /Category/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = categoryService.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }

            var model = new CategoryViewModel()
            {
                Name = category.Name
            };

            return View(model);
        }

        // GET: /Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Category/Create
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

                categoryService.Add(category);

                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: /Category/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = categoryService.Find(id);
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

        // POST: /Category/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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

                categoryService.Modify(category);

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
            Category category = categoryService.Find(id);

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
            Category category = categoryService.Find(id);

            categoryService.Remove(category);

            return RedirectToAction("Index");
        }
    }
}
