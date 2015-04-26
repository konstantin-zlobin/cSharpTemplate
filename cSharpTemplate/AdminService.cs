using System;
using System.Collections.Generic;

namespace cSharpTemplate
{
	public class AdminService
	{
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

            if (club_event.EventDateTime == DateTime.MinValue)
            {
                throw new Exception("validation failed: DateTime must not be null");
            }

            if (club_event.EventDateTime.Date == DateTime.Now.Date || club_event.EventDateTime > DateTime.Now.AddMonths(6))
            {
                throw new Exception("validation failed: Date must not be today");
            }

            if (club_event.Artists == null || club_event.Artists.Count == 0)
            {
                throw new Exception("validation failed: Artists list must not be empty");
            }

            if (club_event.TicketPrices == null || club_event.TicketPrices.Count == 0)
            {
                throw new Exception("validation failed: Ticket prices list must not be empty");
            }

			club_events.Add (club_event);
		}

		public List<ClubEvent> GetAllEvents() {
			return club_events;
		}
	}
}

