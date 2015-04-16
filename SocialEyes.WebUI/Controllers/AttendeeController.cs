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
using System.IO;

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
            return RedirectToAction("Company", "Company", new { id = currentUser.CompanyCode });
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

        //method to display attendees to a particular event
        public ViewResult Attendee(int id)
        {
            //current user
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentUser = manager.FindById(User.Identity.GetUserId());
            ViewBag.CompanyId = currentUser.CompanyCode;
            ViewBag.EventId = id;

            return View(objContext.Attendees.Where(x => x.EventId == id));
        }

        //method to export attendee list to csv file
        public void ExportClientsListToCSV(int id)
        {

            StringWriter sw = new StringWriter();

            sw.WriteLine("\"Event Name\",\"First Name\",\"Surname\",\"Email\",\"Attending\"");

            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment;filename=Attendees.csv");
            Response.ContentType = "text/csv";

            foreach (var line in objContext.Attendees.Where(x => x.EventId == id))
            {
                sw.WriteLine(string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\"",
                    line.SE_Event.EventName,
                    line.FirstName,
                    line.Surname,
                    line.Email,
                    line.Attending));
            }

            Response.Write(sw.ToString());

            Response.End();

        }
    }
}