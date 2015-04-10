using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialEyes.Domain.Entities;

namespace SocialEyes.Domain.Abstract
{
    public interface IUserRepository
    {
        IQueryable<User> Users { get; }

        //code to save user to database
        void SaveUser(User user);

        //code to delete user from database
        User DeleteUser(int userId);
    }
}
