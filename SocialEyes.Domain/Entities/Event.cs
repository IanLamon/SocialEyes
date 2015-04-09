using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialEyes.Domain.Entities
{
    public class Event
    {
        // Primary Key
        public int EventId { get; set; }

        // Data attributes for User
        public string EventImage { get; set; }
        public string EventName { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int MinNum { get; set; }
        public int MaxNum { get; set; }
        public string Gallery { get; set; }
        public string Review { get; set; }
        public string Results { get; set; }

        // Foreign Key setup
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        // Association - one event has many attendances
        public virtual ICollection<Attendee> Attendees { get; set; }

    }
}