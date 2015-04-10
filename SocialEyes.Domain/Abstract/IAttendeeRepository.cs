using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialEyes.Domain.Entities;

namespace SocialEyes.Domain.Abstract
{
    public interface IAttendeeRepository
    {
        IQueryable<Attendee> Attendees { get; }

        //code to save attendee to database
        void SaveAttendee(Attendee attendee);

        //code to delete attendee from database
        Attendee DeleteAttendee(int attendeeId);
    }
}
