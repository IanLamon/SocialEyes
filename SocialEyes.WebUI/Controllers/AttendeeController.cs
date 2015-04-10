﻿using System;
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
            return View(new Attendee());
        }

        [HttpPost]
        public ActionResult Create(Attendee attendee)
        {
            objContext.SaveAttendee(attendee);
            return RedirectToAction("Index");
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
    }
}