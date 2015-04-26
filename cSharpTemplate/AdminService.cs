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
			club_events.Add (club_event);
		}

		public List<ClubEvent> GetAllEvents() {
			return club_events;
		}
	}
}

