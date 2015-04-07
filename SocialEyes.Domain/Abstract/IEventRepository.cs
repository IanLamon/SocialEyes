using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialEyes.Domain.Entities;

namespace SocialEyes.Domain.Abstract
{
    public interface IEventRepository
    {
        IQueryable<Event>Events { get; }

        //code to save event to database
        void SaveEvent(Event se_event);

        //code to delete an event from the database
        Event DeleteEvent(int eventId);
    }
}
