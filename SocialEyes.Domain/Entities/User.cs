using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialEyes.Domain.Entities
{
    public class User
    {
        // Primary Key
        public int UserId { get; set; }

        // Data attributes for User
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public bool Admin { get; set; }

        // Foreign Key setup
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }

        // Association - one user has many attendances
        public virtual ICollection<Attendee> Attendees { get; set; }

        // Association - one user has many poll votes
        public virtual ICollection<PollVote> PollVotes { get; set; }
    }
}
