using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialEyes.Domain.Entities
{
    public class Company
    {
        // Primary Key
        public int CompanyId { get; set; }

        // Data attributes for Company
        public string CompanyName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Address4 { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string LogoURL { get; set; }

        // Association - one company has many users
        public virtual ICollection<User> Users { get; set; }

        // Association - one company has many categories
        public virtual ICollection<Category> Categories { get; set; }

        // Association - one company has many polls
        public virtual ICollection<Poll> Polls { get; set; }
    }
}
