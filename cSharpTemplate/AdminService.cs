using System;
using System.Collections.Generic;

namespace cSharpTemplate
{
	public class AdminService
	{
		private readonly List<ClubEvent> clubEvents;

		public AdminService ()
		{
			clubEvents = new List<ClubEvent> ();
		}

		public void AddEvent(ClubEvent clubEvent) 
		{
			if (clubEvent.Title == null) {
				throw new NullReferenceException("Title must not be null");
			}

			clubEvents.Add(clubEvent);
		}

		public List<ClubEvent> GetAllEvents() {
			return clubEvents;
		}
	}
}

