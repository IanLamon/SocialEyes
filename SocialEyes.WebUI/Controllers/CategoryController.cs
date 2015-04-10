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
    }
}