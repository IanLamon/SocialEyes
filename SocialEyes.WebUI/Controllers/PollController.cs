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
    }
}