using System;
using System.Collections.Generic;
using System.Linq;

namespace cSharpTemplate
{
	public class AdminService
	{
		private readonly List<ClubEvent> clubEvents;

		public AdminService ()
		{
			clubEvents = new List<ClubEvent> ();
		}

		public void AddEvent(ClubEvent newEvent) 
		{
			if (string.IsNullOrEmpty(newEvent.Title))
				throw new ArgumentOutOfRangeException("Title must be defined");

			if (newEvent.DateAndTime.Equals(DateTime.MinValue))
				throw new ArgumentOutOfRangeException("Date and time must be defined");

			if (newEvent.DateAndTime < DateTime.Today.AddDays(1))
				throw new ArgumentOutOfRangeException("Date and time must be in future");

			if (newEvent.Artists == null)
				throw new ArgumentNullException("Artists must not be null");
			if (newEvent.Artists.Count < 1)
				throw new ArgumentOutOfRangeException("There are no artists!");

			if (!newEvent.TicketCategoriesToPrices.ContainsKey(TicketCategories.VIP))
				throw new ArgumentOutOfRangeException("VIP price must be defined");
            if (!newEvent.TicketCategoriesToPrices.ContainsKey(TicketCategories.Simple))
				throw new ArgumentOutOfRangeException("Table price must be defined");
            if (!newEvent.TicketCategoriesToPrices.ContainsKey(TicketCategories.EnterOnly))
				throw new ArgumentOutOfRangeException("Input price must be defined");

			if (clubEvents.Any(e => e.DateAndTime.Date == newEvent.DateAndTime.Date
				&& e.Title == newEvent.Title))
					throw new ArgumentOutOfRangeException("Event with the Same Date and Same title already in list");


			clubEvents.Add(newEvent);
		}

		public List<ClubEvent> GetAllEvents() {
			return clubEvents;
		}

        public Ticket BookEventTicket(Guid clubEventGuid, TicketCategories ticketCategory, string buyerName)
        {
            if (clubEventGuid == null)
                throw new ArgumentException("clubEventGuid is null");

            var clubEvent = clubEvents.FirstOrDefault(ce => ce.ID == clubEventGuid);

            Ticket ticket = null;
            if (clubEvent != null)
                ticket = clubEvent.BookTicket(ticketCategory, buyerName);

            return ticket;
        }

        public Ticket BookEventTicket(Guid clubEventGuid, int ticketId, string buyerName)
        {
            if (clubEventGuid == null)
                throw new ArgumentException("clubEventGuid is null");

            var clubEvent = clubEvents.FirstOrDefault(ce => ce.ID == clubEventGuid);

            Ticket ticket = null;
            if (clubEvent != null)
                ticket = clubEvent.BookTicket(ticketId, buyerName);

            return ticket;
        }
	}
}

