using System;

namespace cSharpTemplate
{
	using NUnit.Framework;

	[TestFixture]
	public class AdminServiceTest
	{
		[Test]
		public void AddEvent_positive ()
		{
			var admin_service = new AdminService ();
			var club_event = new ClubEvent ();
			club_event.title = "Megashow 12345";
			admin_service.AddEvent (club_event);
			Assert.Contains (club_event, admin_service.GetAllEvents ());
		}

		[Test]
		public void AddEvent_validation_failed ()
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