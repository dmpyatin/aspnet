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
      
        //
        // GET: /Category/

        private IDataService DataService;
        private TranslationController Translation; 

        public CategoryController(IDataService dataService)
        {
            this.DataService = dataService;
            Translation = new TranslationController(this.DataService);
        }

        public ActionResult Index()
        {
           
            var cagetories = DataService.GetAllCategories.ToList();

            var categoryModelList =
                cagetories.Select(p =>
                {
                    var categoryModel = new CategoryModel();
                    categoryModel.Id = p.Id;
                    categoryModel.Name = p.Name;
                    return categoryModel;
                }
                    );

            //return View(categoryModelList);
            return Translation.TranslateView(View(categoryModelList), ControllerContext, 1);
        }

        //
        // GET: /Category/Details/5

        public ActionResult Details(int id)
        {
            var category = DataService.GetCategoryById(id);
            var categoryModel = new CategoryModel()
            {
                Id = category.Id,
                Name = category.Name
            };
            return Translation.TranslateView(View(categoryModel), ControllerContext, 1);
        }

        //
        // GET: /Category/Create

        public ActionResult Create()
        {
            var model = new CategoryModel();
            return Translation.TranslateView(View(model), ControllerContext, 1);
        } 

        //
        // POST: /Category/Create

        [HttpPost]
        public ActionResult Create(CategoryModel model)//FormCollection collection
        {
                // TODO: Add insert logic here
                if (model == null)
                    return View(model);

                var category = new Category();
                category.Name = model.Name;

                DataService.Add(category);

                return RedirectToAction("Index");
        }
        
        //
        // GET: /Category/Edit/5
 
        public ActionResult Edit(int id)
        {
            var category = DataService.GetCategoryById(id);
            var categoryModel = new CategoryModel()
            {
                Id = category.Id,
                Name = category.Name
            };
            return Translation.TranslateView(View(categoryModel), ControllerContext, 1);
        }

        //
        // POST: /Category/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, CategoryModel model)
        {
                // TODO: Add update logic here
                if (model == null)
                    return View(model);
                var category = DataService.GetCategoryById(id);
                category.Name = model.Name;

                DataService.Update(category);

                return RedirectToAction("Index");
        }

        //
        // GET: /Category/Delete/5
 
        public ActionResult Delete()
        {
            return Translation.TranslateView(View(), ControllerContext, 1);
        }
    }
}
