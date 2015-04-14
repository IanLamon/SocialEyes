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
            return RedirectToAction("Company", "Company", new { id = user.CompanyId });
        }

        //Update functionality
        public ActionResult Edit(int id)
        {
            User user = objContext.Users.Where(
                x => x.UserId == id).SingleOrDefault();
            return View(user);
        }
        [HttpPost]
        public ActionResult Edit(User model)
        {
            if (ModelState.IsValid)
            {
                objContext.SaveUser(model);
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
            User user = objContext.DeleteUser(id);
            return View(user);
        }

        //display details functionality
        public ViewResult Details(int id)
        {
            User user = objContext.Users.Where(x => x.UserId == id).SingleOrDefault();
            return View(user);
        }

        
    }
}