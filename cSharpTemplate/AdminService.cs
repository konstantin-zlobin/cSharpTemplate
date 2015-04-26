using System;
using System.Collections.Generic;
using System.Linq;

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
            if (club_event.Date == null)
            {
                throw new Exception("validation failed: date must not be null");
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
	}
}

