﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialEyes.Domain.Abstract;
using SocialEyes.Domain.Entities;

namespace SocialEyes.Domain.Concrete
{
    public class EFEventRepository : IEventRepository
    {
        private EFdbContext context = new EFdbContext();

        public IQueryable<Event> Events
        {
            get { return context.Events; }
        }

        //method to save/update event to database
        public void SaveEvent (Event se_event)
        {
            if(se_event.EventID == 0)
            {
                context.Events.Add(se_event);
            }
            else
            {
                Event e = context.Events.Find(se_event.EventID);
                if(e != null)
                {
                    e.CompanyID = se_event.CompanyID;
                    e.CategoryID = se_event.CategoryID;
                    e.EventName = se_event.EventName;
                    e.EventImage = se_event.EventImage;
                    e.Date = se_event.Date;
                    e.Time = se_event.Time;
                    e.Description = se_event.Description;
                    e.Price = se_event.Price;
                    e.MinNum = se_event.MinNum;
                    e.MaxNum = se_event.MaxNum;
                    e.Gallery = se_event.Gallery;
                    e.Review = se_event.Review;
                    e.Results = se_event.Results;
                }
            }
            context.SaveChanges();
        } //ends save/update event method

    } //ends class
}
