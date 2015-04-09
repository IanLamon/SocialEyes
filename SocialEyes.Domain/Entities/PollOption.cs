using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialEyes.Domain.Entities
{
    public class PollOption
    {
        // Primary Key
        public int PollOptionId { get; set; }

        // Data attributes for User
        public int OptionIndex { get; set; }
        public string OptionText { get; set; }

        // Foreign Key setup
        public int PollId { get; set; }
        public virtual Poll Poll { get; set; }

        // Association - one poll option has many votes
        public virtual ICollection<PollVote> PollVotes { get; set; }
    }
}
