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

        //method to create/update user to database
        public void SaveUser(User user)
        {
            if (user.UserId == 0)
            {
                context.Users.Add(user);
            }
            else
            {
                User u = context.Users.Find(user.UserId);
                if (u != null)
                {
                    u.UserId = user.UserId;
                    u.Email = user.Email;
                    u.Password = user.Password;
                    u.FirstName = user.FirstName;
                    u.Surname = user.Surname;
                    u.Admin = user.Admin;
                    u.CompanyId = user.CompanyId;
                }
            }
            context.SaveChanges();
        } //ends create/update user method
    }
}
