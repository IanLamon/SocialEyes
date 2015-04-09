using System;
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
            if(se_event.EventId == 0)
            {
                context.Events.Add(se_event);
            }
            else
            {
                Event e = context.Events.Find(se_event.EventId);
                if(e != null)
                {
                    e.CompanyId = se_event.CompanyId;
                    e.CategoryId = se_event.CategoryId;
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

        //method to delete an event from the database
        public Event DeleteEvent(int eventId)
        {
            Event i = context.Events.Find(eventId);

            if(i != null)
            {
                context.Events.Remove(i);
                context.SaveChanges();
            }
            return i;
        } //ends delete event method

    } //ends class
}
