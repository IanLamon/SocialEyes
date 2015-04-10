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

        void SavePollOption(PollOption pollOption);
    }
}
