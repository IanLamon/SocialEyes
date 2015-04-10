using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialEyes.Domain.Abstract;
using SocialEyes.Domain.Entities;

namespace SocialEyes.Domain.Concrete
{
    public class EFPollOptionRepository : IPollOptionRepository
    {
        private EFdbContext context = new EFdbContext();

        public IQueryable<PollOption> PollOptions
        {
            get { return context.PollOptions; }
        }

        //method to create/update poll option to database
        public void SavePollOption(PollOption pollOption)
        {
            if (pollOption.PollOptionId == 0)
            {
                context.PollOptions.Add(pollOption);
            }
            else
            {
                PollOption po = context.PollOptions.Find(pollOption.PollOptionId);
                if (po != null)
                {
                    po.PollOptionId = pollOption.PollOptionId;
                    po.OptionIndex = pollOption.OptionIndex;
                    po.OptionText = pollOption.OptionText;
                    po.PollId = pollOption.PollId;
                }
            }
            context.SaveChanges();
        } //ends create/update PollOption method

        //method to delete poll option from database
        public PollOption DeletePollOption(int pollOptionId)
        {
            PollOption x = context.PollOptions.Find(pollOptionId);

            if (x != null)
            {
                context.PollOptions.Remove(x);
                context.SaveChanges();
            }
            return x;
        } //ends delete method
    }
}
