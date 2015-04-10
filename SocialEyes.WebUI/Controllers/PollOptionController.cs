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
    }
}