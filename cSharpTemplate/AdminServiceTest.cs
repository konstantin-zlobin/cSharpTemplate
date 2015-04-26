using System;

namespace cSharpTemplate
{
	using NUnit.Framework;

	[TestFixture]
	public class AdminServiceTest
	{
		/// <summary>
		/// Test an event addition
		/// </summary>
		[Test]
		public void AddEvent_positive()
		{
			var admin_service = new AdminService();
			var club_event = new ClubEvent();
			club_event.Title = "Megashow 12345";
			club_event.EventDateTime = new DateTime(2015, 4, 30, 19, 00, 00);
			club_event.Artists = new System.Collections.Generic.List<string>() { "Artist1", "Artist2" };
			club_event.TicketPrices = new System.Collections.Generic.Dictionary<PriceCategory, decimal> 
				{
					{PriceCategory.VIP, 1000}, 
					{PriceCategory.Table, 700},
					{PriceCategory.Entery, 500}
				};
			admin_service.AddEvent(club_event);
			Assert.Contains(club_event, admin_service.GetAllEvents());
		}

		/// <summary>
		/// Test an event exeption
		/// </summary>
		[Test]
		public void AddEvent_validation_failed()
		{
			var admin_service = new AdminService();
			var title = "Megashow 12345";
			var eventDateTime = new DateTime(2015, 4, 30, 19, 00, 00);
			var artists = new System.Collections.Generic.List<string>() { "Artist1", "Artist2" };
			var ticketPrices = new System.Collections.Generic.Dictionary<PriceCategory, decimal> 
				{
				{PriceCategory.VIP, 1000}, 
				{PriceCategory.Table, 700},
				{PriceCategory.Entery, 500}
				};

			var club_event = new ClubEvent() { EventDateTime = eventDateTime, Artists = artists, TicketPrices = ticketPrices };
			Assert.Throws<Exception>(
					delegate
					{
						admin_service.AddEvent(club_event);
					}
				);

			club_event = new ClubEvent() { Title = title, Artists = artists, TicketPrices = ticketPrices };
			Assert.Throws<Exception>(
					delegate
					{
						admin_service.AddEvent(club_event);
					}
				);

			club_event = new ClubEvent() { EventDateTime = eventDateTime, Title = title, TicketPrices = ticketPrices };
			Assert.Throws<Exception>(
					delegate
					{
						admin_service.AddEvent(club_event);
					}
				);

			club_event = new ClubEvent() { EventDateTime = eventDateTime, Artists = artists, Title = title };
			Assert.Throws<Exception>(
					delegate
					{
						admin_service.AddEvent(club_event);
					}
				);
		}


	}
}