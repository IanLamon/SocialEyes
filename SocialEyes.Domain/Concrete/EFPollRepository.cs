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
    }
}
