using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace cSharpTemplate
{
	[TestFixture]
	public class AdminServiceTests
	{
		[Test]
		public void AddEvent_Test()
		{
			var admin_service = new AdminService ();
			var club_event = new ClubEvent ();
			club_event.Title = "Megashow 12345";
            club_event.Date = new DateTime(2015, 5, 1, 18, 0, 0); ;
            club_event.Time = new DateTime(2015, 5, 1, 18, 0, 0); ;
			club_event.Performers = new List<string>() {"1"};
			club_event.PriceList.Add(TicketCategory.VIP, 1);
			admin_service.AddEvent (club_event);
			Assert.Contains (club_event, admin_service.GetAllEvents ());
		}

		[Test]
		public void AddEvent_NoTitle_ThrowsException_Test()
		{
			var admin_service = new AdminService ();
			var club_event = new ClubEvent ();
			Assert.Throws<Exception>(
				delegate 
				{ 
					admin_service.AddEvent (club_event);
				}
			);
		}
	}
}
