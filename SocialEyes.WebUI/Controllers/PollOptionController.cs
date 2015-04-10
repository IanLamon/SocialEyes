using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SocialEyes.Domain.Abstract;

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
    }
}