using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SocialEyes.Domain.Abstract;
using SocialEyes.Domain.Entities;
using Microsoft.AspNet.Identity;
using SocialEyes.WebUI.Models;
using Microsoft.AspNet.Identity.EntityFramework;

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
            //current user
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentUser = manager.FindById(User.Identity.GetUserId());
            int eventId;
            int.TryParse(Request.QueryString["eventId"], out eventId);
            string eventName = Request.QueryString["eventName"];

            ViewBag.EventName = eventName;
            ViewBag.CompanyId = currentUser.CompanyCode;

            //attendee object
            Attendee currentAttendee = new Attendee
            {
                EventId = eventId,
                FirstName = currentUser.FirstName,
                Surname = currentUser.Surname,
                CompanyId = currentUser.CompanyCode,
                Email = currentUser.Email,
            };


            
            return View(currentAttendee);
        }

        [HttpPost]
        public ActionResult Create(Attendee attendee)
        {
            //current user
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentUser = manager.FindById(User.Identity.GetUserId());

            attendee.FirstName = currentUser.FirstName;
            attendee.Surname = currentUser.Surname;
            attendee.CompanyId = currentUser.CompanyCode;
            attendee.Email = currentUser.Email;
            
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