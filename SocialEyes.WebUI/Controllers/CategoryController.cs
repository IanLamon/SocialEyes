using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SocialEyes.Domain.Abstract;
using SocialEyes.Domain.Entities;

namespace SocialEyes.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryRepository objContext;

        public CategoryController (ICategoryRepository categoryRepository)
        {
            this.objContext = categoryRepository;
        }

        // GET: Category
        public ActionResult Index()
        {
            return View(objContext.Categories);
        }

        //create method
        public ActionResult Create()
        {
            return View(new Category());
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {
            objContext.SaveCategory(category);
            return RedirectToAction("Index");
        }

        //Update functionality
        public ActionResult Edit(int id)
        {
            Category category = objContext.Categories.Where(
                x => x.CategoryId == id).SingleOrDefault();
            return View(category);
        }
        [HttpPost]
        public ActionResult Edit(Category model)
        {
            if (ModelState.IsValid)
            {
                objContext.SaveCategory(model);
                return RedirectToAction("Index");
            }
            else
            {
                //problem processing request
                return View(model);
            }
        }

        //delete functionality
        public ActionResult Delete(int id)
        {
            Category category = objContext.DeleteCategory(id);
            return View(category);
        }

        //display details functionality
        public ViewResult Details(int id)
        {
            Category category = objContext.Categories.Where(x => x.CategoryId == id).SingleOrDefault();
            return View(category);
        }
    }
}