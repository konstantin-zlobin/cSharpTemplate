using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cSharpTemplate
{
    public class Ticket
    {
        /// <summary>
        /// Category of ticket 
        /// </summary>
        public TicketCategory Category;

        /// <summary>
        /// Place of ticket
        /// </summary>
        public int TicketPlace {get; set;}
    }
}
