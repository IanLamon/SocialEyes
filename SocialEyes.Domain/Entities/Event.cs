using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialEyes.Domain.Entities
{
    public class Event
    {
        public int EventID { get; set; }
        public int CompanyID { get; set; }
        public int CategoryID { get; set; }
        public string EventImage { get; set; }
        public string EventName { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int MinNum { get; set; }
        public int MaxNum { get; set; }
        public string Gallery { get; set; }
        public string Review { get; set; }
        public string Results { get; set; }
    }
}