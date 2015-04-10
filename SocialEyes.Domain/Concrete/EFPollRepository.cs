using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialEyes.Domain.Abstract;
using SocialEyes.Domain.Entities;

namespace SocialEyes.Domain.Concrete
{
    public class EFPollRepository : IPollRepository
    {
        private EFdbContext context = new EFdbContext();

        public IQueryable<Poll> Polls
        {
            get { return context.Polls; }
        }

        //method to create/update poll to database
        public void SavePoll(Poll poll)
        {
            if (poll.PollId == 0)
            {
                context.Polls.Add(poll);
            }
            else
            {
                Poll p = context.Polls.Find(poll.PollId);
                if (p != null)
                {
                    p.PollId = poll.PollId;
                    p.PollName = poll.PollName;
                    p.PollQuestion = poll.PollQuestion;
                    p.EndDate = poll.EndDate;
                    p.CompanyId = poll.CompanyId;
                }
            }
            context.SaveChanges();
        } //ends create/update poll method
    }
}
