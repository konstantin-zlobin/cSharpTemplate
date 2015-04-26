using System;
using System.Collections.Generic;

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
	public struct ClubEvent
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
	}
}

