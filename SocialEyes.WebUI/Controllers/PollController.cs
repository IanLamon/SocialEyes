using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SocialEyes.Domain.Abstract;
using SocialEyes.Domain.Entities;

namespace SocialEyes.WebUI.Controllers
{
    public class PollController : Controller
    {
        private IPollRepository objContext;

        public PollController (IPollRepository pollRepository)
        {
            this.objContext = pollRepository;
        }

        // GET: Poll
        public ActionResult Index()
        {
            return View(objContext.Polls);
        }

        //create method
        public ActionResult Create()
        {
            return View(new Poll());
        }

        [HttpPost]
        public ActionResult Create(Poll poll)
        {
            objContext.SavePoll(poll);
            return RedirectToAction("Index");
        }

        //Update functionality
        public ActionResult Edit(int id)
        {
            Poll poll = objContext.Polls.Where(
                x => x.PollId == id).SingleOrDefault();
            return View(poll);
        }
        [HttpPost]
        public ActionResult Edit(Poll model)
        {
            if (ModelState.IsValid)
            {
                objContext.SavePoll(model);
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
            Poll poll = objContext.DeletePoll(id);
            return View(poll);
        }
    }
}