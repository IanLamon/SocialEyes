using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SocialEyes.Domain.Abstract;

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
    }
}