using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cSharpTemplate
{
    public class Ticket
    {
        public int ID { get; set; }
        public TicketCategories Category { get; set; }
        public bool IsSold { get; set; }
    }
}
