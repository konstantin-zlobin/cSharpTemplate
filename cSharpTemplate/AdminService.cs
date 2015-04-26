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

			if (newEvent.DateTime.Equals(DateTime.MinValue))
				throw new ArgumentOutOfRangeException("Date and time must be defined");

			if (newEvent.DateTime < DateTime.Today.AddDays(1))
				throw new ArgumentOutOfRangeException("Date and time must be in future");

			if (newEvent.Artists == null)
				throw new ArgumentNullException("Artists must not be null");
			if (newEvent.Artists.Length < 1)
				throw new ArgumentOutOfRangeException("There are no artists!");

			if (newEvent.VipPrice == 0)
				throw new ArgumentOutOfRangeException("VIP price must be defined");
			if (newEvent.TablePrice == 0)
				throw new ArgumentOutOfRangeException("Table price must be defined");
			if (newEvent.CheapestPrice == 0)
				throw new ArgumentOutOfRangeException("Input price must be defined");

			if (clubEvents.Any(e => e.DateTime.Date == newEvent.DateTime.Date
				&& e.Title == newEvent.Title))
					throw new ArgumentOutOfRangeException("Event with the Same Date and Same title already in list");


			clubEvents.Add(newEvent);
		}

		public List<ClubEvent> GetAllEvents() {
			return clubEvents;
		}
	}
}

