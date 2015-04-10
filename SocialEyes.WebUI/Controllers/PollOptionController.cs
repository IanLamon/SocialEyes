using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SocialEyes.Domain.Abstract;
using SocialEyes.Domain.Entities;

namespace SocialEyes.WebUI.Controllers
{
    public class PollOptionController : Controller
    {
        private IPollOptionRepository objContext;

        public PollOptionController (IPollOptionRepository pollOptionRepository)
        {
            this.objContext = pollOptionRepository;
        }

        // GET: PollOption
        public ActionResult Index()
        {
            return View(objContext.PollOptions);
        }

        //create method
        public ActionResult Create()
        {
            return View(new PollOption());
        }

        [HttpPost]
        public ActionResult Create(PollOption pollOption)
        {
            objContext.SavePollOption(pollOption);
            return RedirectToAction("Index");
        }

        //Update functionality
        public ActionResult Edit(int id)
        {
            PollOption pollOption = objContext.PollOptions.Where(
                x => x.PollOptionId == id).SingleOrDefault();
            return View(pollOption);
        }
        [HttpPost]
        public ActionResult Edit(PollOption model)
        {
            if (ModelState.IsValid)
            {
                objContext.SavePollOption(model);
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
            PollOption pollOption = objContext.DeletePollOption(id);
            return View(pollOption);
        }

        //display details functionality
        public ViewResult Details(int id)
        {
            PollOption pollOption = objContext.PollOptions.Where(x => x.PollOptionId == id).SingleOrDefault();
            return View(pollOption);
        }
    }
}