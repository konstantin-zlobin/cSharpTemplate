using System;
using System.Collections.Generic;
using System.Linq;

namespace cSharpTemplate
{
	public class AdminService
	{
		const int VIPTotal = 10;
		const int GeneralTotal = 25;
		const int EntranceTotal = 100;

		private readonly List<ClubEvent> club_events;

		public AdminService ()
		{
			club_events = new List<ClubEvent> ();
		}

		public void AddEvent(ClubEvent club_event) 
		{
			if (club_event.Title == null) {
				throw new Exception ("validation failed: title must not be null");
			}
            if (club_event.Date == null)
            {
                throw new Exception("validation failed: date must not be null");
            }

            if (club_event.Date.Date <= DateTime.Now.Date)
            {
                throw new Exception("validation failed: date must be bigger then today");
            }

            if (club_event.Date.Date > DateTime.Now.AddMonths(6))
            {
                throw new Exception("validation failed: date must not be bigger then today + 6 month");
            }

            if (club_event.Time == null)
            {
                throw new Exception("validation failed: time must not be null");
            }
            if (club_event.Performers == null || !club_event.Performers.Any())
            {
                throw new Exception("validation failed: performers must not be null");
            }
            if (club_event.PriceList == null || club_event.PriceList.Count == 0)
            {
                throw new Exception("validation failed: pricelist must not be null");
            }
			club_events.Add (club_event);
		}

		public List<ClubEvent> GetAllEvents() {
			return club_events;
		}

        /// <summary>
        /// Sell ticket
        /// </summary>
        /// <param name="title">event title</param>
        /// <param name="ticket">ticket</param>
        public void SellTicket(string title, Ticket ticket)
        {
            var clubEvent = club_events.Find(e => e.Title.Equals(title));
            switch (ticket.Category)
            {
                case TicketCategory.VIP :
					if (clubEvent.Tickets.Count(e => e.Category == TicketCategory.VIP) == VIPTotal)
                    {
                        throw new Exception("No more VIP tickets");
                    }
                    if (clubEvent.Tickets.Any(e => e.Category == TicketCategory.VIP && e.TicketPlace == ticket.TicketPlace))
                    {
                        throw new Exception("This ticket is sold");
                    }
                    break;

                case TicketCategory.General:
					if (clubEvent.Tickets.Count(e => e.Category == TicketCategory.General) == GeneralTotal)
                    {
                        throw new Exception("No more VIP tickets");
                    }
                    if (clubEvent.Tickets.Any(e => e.Category == TicketCategory.General && e.TicketPlace == ticket.TicketPlace))
                    {
                        throw new Exception("This ticket is sold");
                    }
                    break;

                case TicketCategory.Entrance:
					if (clubEvent.Tickets.Count(e => e.Category == TicketCategory.Entrance) == EntranceTotal)
                    {
                        throw new Exception("No more VIP tickets");
                    }
                    break;
            }
            
            clubEvent.Tickets.Add(ticket);
			ticket.IsSold = true;
        }

		internal bool BookTicket(string title, Ticket ticket)
		{
			var clubEvent = club_events.Find(e => e.Title.Equals(title));
			Ticket processedTicket = FindTicket(clubEvent, ticket);
			if (processedTicket == null)
			{
				switch (ticket.Category)
				{
					case TicketCategory.VIP:
						if (clubEvent.Tickets.Count(e => e.Category == TicketCategory.VIP) == VIPTotal)
						{
							return false;
						}
						break;

					case TicketCategory.General:
						if (clubEvent.Tickets.Count(e => e.Category == TicketCategory.General) == GeneralTotal)
						{
							return false;
						}
						break;

					//case TicketCategory.Entrance:
					//	if (clubEvent.Tickets.Count(e => e.Category == TicketCategory.Entrance) == EntranceTotal)
					//	{
					//		throw new Exception("No more VIP tickets");
					//	}
					//	break;
				}

				clubEvent.Tickets.Add(ticket);
				return true;
			}

			return false;
		}

		private Ticket FindTicket(ClubEvent clubEvent, Ticket ticket)
		{
			switch (ticket.Category)
			{
				case TicketCategory.VIP:
					return clubEvent.Tickets.Find(e => e.Category == TicketCategory.VIP && e.TicketPlace == ticket.TicketPlace);

				case TicketCategory.General:
					return (clubEvent.Tickets.Find(e => e.Category == TicketCategory.General && e.TicketPlace == ticket.TicketPlace));

				default:
					return null;
			}
		}

		internal bool SellBookedTicket(string title, Ticket ticket)
		{
			var clubEvent = club_events.Find(e => e.Title.Equals(title));
			Ticket bookedTicket = FindTicket(clubEvent, ticket);
			if (bookedTicket == null)
			{
				throw new InvalidOperationException("Booked ticket not found");
			}
			if (bookedTicket.User != ticket.User)
			{
				throw new InvalidOperationException("Ticket booked by another person");
			}

			bookedTicket.IsSold = true;
			return true;
		}
	}
}

