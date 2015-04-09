using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialEyes.Domain.Abstract;
using SocialEyes.Domain.Entities;

namespace SocialEyes.Domain.Concrete
{
    public class EFUserRepository : IUserRepository
    {
        private EFdbContext context = new EFdbContext();

        public IQueryable<User> Users
        {
            get { return context.Users; }
        }
    }
}
