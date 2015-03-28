using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SocialEyes.Domain.Abstract;
using SocialEyes.Domain.Entities;

namespace SocialEyes.WebUI.Controllers
{
    public class EventController : Controller
    {
        private IEventRepository repository;

        public EventController(IEventRepository eventRepository)
        {
            this.repository = eventRepository;
        }

        public ViewResult Index()
        {
            return View(repository.Events);
        }

        //method for admin view
        public ViewResult Admin()
        {
            return View(repository.Events);
        }

        //method for admin to edit event
        public ViewResult Edit(int id)
        {
            Event se_event = repository.Events.FirstOrDefault(i => i.EventID == id);
            return View(se_event);
        }

        //method to Edit POST requests
        [HttpPost]
        public ActionResult Edit (Event se_event)
        {
            if (ModelState.IsValid)
            {
                repository.SaveEvent(se_event);
                return RedirectToAction("Admin");
            }
            else
            {
                //if there is a problem processing the request
                return View(se_event);
            }
        } //ends edit post method

        //method to display event detail
        public ViewResult Details (int id)
        {
            Event se_event = repository.Events.FirstOrDefault(i => i.EventID == id);
            return View(se_event);
        }

        // GET: Event
        //public ActionResult Index()
        //{
        //    return View();
        //}
    }
}