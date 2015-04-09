using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SocialEyes.Domain.Entities
{
    public class Attendee
    {
        // Primary Key
        [Key]
        public int AttendeeId { get; set; }

        // Data attributes for User
        public bool Attending { get; set; }

        // Foreign Key setup
        public int EventId { get; set; }
        public virtual Event SE_Event { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
