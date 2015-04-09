using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialEyes.Domain.Entities
{
    public class Category
    {
        // Primary Key
        public int CategoryId { get; set; }

        // Data attributes for Category
        public string Name { get; set; }
        public string CategoryImageURL { get; set; }
        
        // Foreign Key setup
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }

        // Association - one category has many events
        public virtual ICollection<Event> Events { get; set; }
    }
}
