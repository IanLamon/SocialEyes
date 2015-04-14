using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SocialEyes.Domain.Abstract;
using SocialEyes.Domain.Entities;

namespace SocialEyes.WebUI.Controllers
{
    public class AttendeeController : Controller
    {
        private IAttendeeRepository objContext;

        public AttendeeController (IAttendeeRepository attendeeRepository)
        {
            this.objContext = attendeeRepository;
        }
        
        // GET: Attendee
        public ActionResult Index()
        {
            return View(objContext.Attendees);
        }

        //create method
        public ActionResult Create()
        {
            string eventId = Request.QueryString["eventId"];
            string eventName = Request.QueryString["eventName"];
            string userName = Request.QueryString["username"];
            int companyId = int.Parse(Request.QueryString["companyId"]);
            ViewBag.EventId = eventId;
            ViewBag.EventName = eventName;
            ViewBag.UserName = userName;
            ViewBag.CompanyId = companyId;
            return View(new Attendee());
        }

        [HttpPost]
        public ActionResult Create(Attendee attendee)
        {
            objContext.SaveAttendee(attendee);
            return RedirectToAction("Company", "Company", new { id = 2 });
        }

        //Update functionality
        public ActionResult Edit(int id)
        {
            Attendee attendee = objContext.Attendees.Where(
                x => x.AttendeeId == id).SingleOrDefault();
            return View(attendee);
        }
        [HttpPost]
        public ActionResult Edit(Attendee model)
        {
            if(ModelState.IsValid)
            {
                objContext.SaveAttendee(model);
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
            Attendee attendee = objContext.DeleteAttendee(id);
            return View(attendee);
        }

        //display details functionality
        public ViewResult Details(int id)
        {
            Attendee attendee = objContext.Attendees.Where(x => x.AttendeeId == id).SingleOrDefault();
            return View(attendee);
        }
    }
}