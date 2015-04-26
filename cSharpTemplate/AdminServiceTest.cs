using System;
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
