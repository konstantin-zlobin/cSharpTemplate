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
			var adminService = new AdminService();
			var clubEvent = new ClubEvent();
			clubEvent.Title = "Megashow 12345";

			adminService.AddEvent(clubEvent);

			Assert.Contains(clubEvent, adminService.GetAllEvents());
		}

		[Test]
		public void AddEvent_validation_failed ()
		{
			var adminService = new AdminService();
			var clubEvent = new ClubEvent();

			Assert.Throws<NullReferenceException>(
				delegate 
				{ 
					adminService.AddEvent(clubEvent);
				}
			);
		}
	}
}