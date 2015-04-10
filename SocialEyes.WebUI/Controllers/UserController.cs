using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SocialEyes.Domain.Abstract;
using SocialEyes.Domain.Entities;

namespace SocialEyes.WebUI.Controllers
{
    public class UserController : Controller
    {
        private IUserRepository objContext;

        public UserController (IUserRepository userRepository)
        {
            this.objContext = userRepository;
        }

        // GET: User
        public ActionResult Index()
        {
            return View(objContext.Users);
        }

        //create method
        public ActionResult Create()
        {
            return View(new User());
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            objContext.SaveUser(user);
            return RedirectToAction("Index");
        }
    }
}