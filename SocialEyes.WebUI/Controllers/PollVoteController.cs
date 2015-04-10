using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SocialEyes.Domain.Abstract;
using SocialEyes.Domain.Entities;

namespace SocialEyes.WebUI.Controllers
{
    public class PollVoteController : Controller
    {
        private IPollVoteRepository objContext;

        public PollVoteController (IPollVoteRepository pollVoteRepository)
        {
            this.objContext = pollVoteRepository;
        }

        // GET: PollVote
        public ActionResult Index()
        {
            return View(objContext.PollVotes);
        }

        //create method
        public ActionResult Create()
        {
            return View(new PollVote());
        }

        [HttpPost]
        public ActionResult Create(PollVote pollVote)
        {
            objContext.SavePollVote(pollVote);
            return RedirectToAction("Index");
        }

        //Update functionality
        public ActionResult Edit(int id)
        {
            PollVote pollVote = objContext.PollVotes.Where(
                x => x.PollVoteId == id).SingleOrDefault();
            return View(pollVote);
        }
        [HttpPost]
        public ActionResult Edit(PollVote model)
        {
            if (ModelState.IsValid)
            {
                objContext.SavePollVote(model);
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
            PollVote pollVote = objContext.DeletePollVote(id);
            return View(pollVote);
        }
    }
}