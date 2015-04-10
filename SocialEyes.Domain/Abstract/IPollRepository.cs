using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialEyes.Domain.Entities;

namespace SocialEyes.Domain.Abstract
{
    public interface IPollRepository
    {
        IQueryable<Poll> Polls { get; }

        //code to save poll to database
        void SavePoll(Poll poll);

        //code to delete poll from database
        Poll DeletePoll(int pollId);
    }
}
