using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialEyes.Domain.Abstract;
using SocialEyes.Domain.Entities;

namespace SocialEyes.Domain.Concrete
{
    public class EFAttendeeRepository : IAttendeeRepository
    {
        private EFdbContext context = new EFdbContext();

        public IQueryable<Attendee> Attendees
        {
            get { return context.Attendees; }
        }

        //method to create/update attendee to database
        public void SaveAttendee(Attendee attendee)
        {
            if (attendee.AttendeeId== 0)
            {
                context.Attendees.Add(attendee);
            }
            else
            {
                Attendee a = context.Attendees.Find(attendee.AttendeeId);
                if (a != null)
                {
                    a.AttendeeId = attendee.AttendeeId;
                    a.Attending = attendee.Attending;
                    a.EventId = attendee.EventId;
                    a.FirstName = attendee.FirstName;
                    a.Surname = attendee.Surname;
                    a.Email = attendee.Email;
                    a.CompanyId = attendee.CompanyId;
                }
            }
            context.SaveChanges();
        } //ends create/update event method

        //method to delete attendee from database
        public Attendee DeleteAttendee(int attendeeId)
        {
            Attendee x = context.Attendees.Find(attendeeId);

            if(x != null)
            {
                context.Attendees.Remove(x);
                context.SaveChanges();
            }
            return x;
        } //ends delete method
    }
}
