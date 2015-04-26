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
			if (string.IsNullOrEmpty(clubEvent.Title))
				throw new ArgumentOutOfRangeException("Title must be defined");

			if (clubEvent.DateTime.Equals(DateTime.MinValue))
				throw new ArgumentOutOfRangeException("Date and time must be defined");

			if (clubEvent.Artists == null)
				throw new ArgumentNullException("Artists must not be null");
			if (clubEvent.Artists.Length < 1)
				throw new ArgumentOutOfRangeException("There are no artists!");

			if (clubEvent.VipPrice == 0)
				throw new ArgumentOutOfRangeException("VIP price must be defined");
			if (clubEvent.TablePrice == 0)
				throw new ArgumentOutOfRangeException("Table price must be defined");
			if (clubEvent.CheapestPrice == 0)
				throw new ArgumentOutOfRangeException("Input price must be defined");


			clubEvents.Add(clubEvent);
		}

		public List<ClubEvent> GetAllEvents() {
			return clubEvents;
		}
	}
}

