using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialEyes.Domain.Entities;

namespace SocialEyes.Domain.Abstract
{
    public interface IPollOptionRepository
    {
        IQueryable<PollOption> PollOptions { get; }

        //code to save poll option to database
        void SavePollOption(PollOption pollOption);

        //code to delete poll option from database
        PollOption DeletePollOption(int pollOptionId);
    }
}
