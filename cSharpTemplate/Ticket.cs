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

		public string User { get; set; }

		public bool IsBooked { get { return string.IsNullOrEmpty(User); } }

		public  bool IsSold { get; set; }
	}
}
