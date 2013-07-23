using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EfRepPatTest.Entity;
using EfRepPatTest.Service;
using Web.Implementation.Models;

namespace Web.Implementation.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryService categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        //
        // GET: /Category/

        public ActionResult Index()
        {
            var cagetories = categoryService.GetAll().ToList();

            var categoryModelList =
                cagetories.Select(p =>
                {
                    var categoryModel = new CategoryModel();
                    categoryModel.Id = p.Id;
                    categoryModel.Name = p.Name;

                    return categoryModel;
                }
                    );
            return View(categoryModelList);
        }

        //
        // GET: /Category/Details/5

        public ActionResult Details(int id)
        {
            var category = categoryService.GetById(id);
            var categoryModel = new CategoryModel()
            {
                Id = category.Id,
                Name = category.Name
            };
            return View(categoryModel);
        }

        //
        // GET: /Category/Create

        public ActionResult Create()
        {
            var model = new CategoryModel();
            return View(model);
        } 

        //
        // POST: /Category/Create

        [HttpPost]
        public ActionResult Create(CategoryModel model)//FormCollection collection
        {
            try
            {
                // TODO: Add insert logic here
                if (model == null)
                    return View(model);

                var category = new Category();
                category.Name = model.Name;

                categoryService.Insert(category);

                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }
        
        //
        // GET: /Category/Edit/5
 
        public ActionResult Edit(int id)
        {
            var category = categoryService.GetById(id);
            var categoryModel = new CategoryModel()
                {
                    Id = category.Id,
                    Name = category.Name
                };
            return View(categoryModel);
        }

        //
        // POST: /Category/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, CategoryModel model)
        {
            try
            {
                // TODO: Add update logic here
                if (model == null)
                    return View(model);
                var category= categoryService.GetById(id);
                category.Name = model.Name;

                categoryService.Update(category);

                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }

        //
        // GET: /Category/Delete/5
 
        public ActionResult Delete(int id)
        {
            var category = categoryService.GetById(id);

            var categoryModel = new CategoryModel()
            {
                Id = category.Id,
                Name = category.Name
            };
            return View(categoryModel);

        }

        //
        // POST: /Category/Delete/5

        [HttpPost]
        public ActionResult Delete(int id,  CategoryModel model)
        {
            try
            {
                // TODO: Add delete logic here

                if (id ==0)
                    return RedirectToAction("Index");

                var category = categoryService.GetById(id);

                categoryService.Delete(category);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
