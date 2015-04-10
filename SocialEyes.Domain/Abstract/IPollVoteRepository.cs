using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialEyes.Domain.Entities;

namespace SocialEyes.Domain.Abstract
{
    public interface IPollVoteRepository
    {
        IQueryable<PollVote> PollVotes { get; }

        //code to save poll vote to database
        void SavePollVote(PollVote pollVote);

        //code to delete poll vote from database
        PollVote DeletePollVote(int pollVoteId);
    }
}
