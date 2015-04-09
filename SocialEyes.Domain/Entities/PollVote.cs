using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialEyes.Domain.Entities
{
    public class PollVote
    {
        // Primary Key
        public int PollVoteId { get; set; }

        // Foreign Key setup
        public int PollId { get; set; }
        public virtual Poll Poll { get; set; }

        public int PollOptionId { get; set; }
        public virtual PollOption PollOption { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
