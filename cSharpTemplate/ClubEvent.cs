using System;
using System.Collections.Generic;
using System.Linq;

namespace cSharpTemplate
{
	public enum PriceCategory
	{
		VIP, //ticket for VIP
		Table, //Entery and Table
		Entery //Just Entery
	}

	/// <summary>
	/// Concert model
	/// </summary>
	public class ClubEvent
	{
		/// <summary>
		/// Concert title
		/// </summary>
		public String Title { get; set; }

		/// <summary>
		/// Concert date
		/// </summary>
		public DateTime EventDateTime { get; set; }

		/// <summary>
		/// Concert time
		/// </summary>
		public string EventTime
		{
			get
			{
				return EventDateTime.TimeOfDay.ToString(@"hh\:mm");
			}
		}

		/// <summary>
		/// List of artists
		/// </summary>
		public List<string> Artists { get; set; }

		/// <summary>
		/// Ticket prices
		/// </summary>
		public Dictionary<PriceCategory, decimal> TicketPrices { get; set; }

        public List<Ticket> Tickets { get; set; }

        private static int expirationTimeInMinutes = 30;
        public ClubEvent()
        {
            Tickets = new List<Ticket>();
        }

        public bool ChangeTicketState(TicketState targetState, int ticketId)
        {
            var ticket = Tickets.FirstOrDefault(t => t.ID == ticketId);
            
            if (ticket != null)
            {
               if (ticket.State == TicketState.Sold)
                    return false;
                switch (targetState)
                {
                    case TicketState.Free:
                            if (IsReservationExpired(ticket))
                                ticket.State = targetState;
                       
                        break;
                    case TicketState.Reserved:
                        if (ticket.State == TicketState.Free)
                        {
                            ticket.State = targetState;
                        }
                        else
                            return false;

                        break;
                    case TicketState.Sold:
                        if ((ticket.State == TicketState.Free) || !IsReservationExpired(ticket))
                            ticket.State = TicketState.Sold;
                        else
                            return false;
                        break;
                }
            }
            return true;
        }

        public bool IsReservationExpired(Ticket ticket)
        {
           return (DateTime.UtcNow - ticket.ReservedAt).Minutes > expirationTimeInMinutes;
        }


       
	}
}

