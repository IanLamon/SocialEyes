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
    }
}
