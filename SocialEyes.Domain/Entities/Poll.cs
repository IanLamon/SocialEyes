using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialEyes.Domain.Entities
{
    public class Poll
    {
        // Primary Key
        public int PollId { get; set; }

        // Data attributes for User
        public string PollName { get; set; }
        public string PollQuestion { get; set; }
        public DateTime EndDate { get; set; }

        // Foreign Key setup
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }

        // Association - one poll has many votes
        public virtual ICollection<PollVote> PollVotes { get; set; }

        // Association - one poll has many vote options
        public virtual ICollection<PollOption> PollOptions { get; set; }
    }
}
