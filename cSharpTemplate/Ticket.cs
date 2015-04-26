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
        public PriceCategory Category { get; set; }
        public TicketState State { get; set; }
        public DateTime ReservedAt { get; set; }
    }

    public enum TicketState
    {
        Free,
        Reserved,
        Sold
    }
}
