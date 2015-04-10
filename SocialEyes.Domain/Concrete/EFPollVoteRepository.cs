using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialEyes.Domain.Abstract;
using SocialEyes.Domain.Entities;

namespace SocialEyes.Domain.Concrete
{
    public class EFPollVoteRepository : IPollVoteRepository
    {
        private EFdbContext context = new EFdbContext();

        public IQueryable<PollVote> PollVotes
        {
            get { return context.PollVotes; }
        }

        //method to create/update poll vote to database
        public void SavePollVote(PollVote pollVote)
        {
            if (pollVote.PollVoteId == 0)
            {
                context.PollVotes.Add(pollVote);
            }
            else
            {
                PollVote pv = context.PollVotes.Find(pollVote.PollVoteId);
                if (pv != null)
                {
                    pv.PollVoteId = pollVote.PollVoteId;
                    pv.PollId = pollVote.PollId;
                    pv.PollOptionId = pollVote.PollOptionId;
                    pv.UserId = pollVote.UserId;
                }
            }
            context.SaveChanges();
        } //ends create/update poll vote method

        //method to delete attendee from database
        public PollVote DeletePollVote(int pollVoteId)
        {
            PollVote x = context.PollVotes.Find(pollVoteId);

            if (x != null)
            {
                context.PollVotes.Remove(x);
                context.SaveChanges();
            }
            return x;
        } //ends delete method
    }
}
