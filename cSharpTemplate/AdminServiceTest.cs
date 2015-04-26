using System;

namespace cSharpTemplate
{
	using NUnit.Framework;
    using System.Collections.Generic;

	[TestFixture]
	public class AdminServiceTest
	{
		ClubEvent clubEvent;

		[SetUp]
		public void InitClubEvent()
		{
			clubEvent = new ClubEvent();
			clubEvent.Title = "Megashow 12345";
			clubEvent.DateAndTime = DateTime.Now.AddDays(2);
			clubEvent.Artists = new List<string> { "Volodya", "Oleg" };
            clubEvent.TicketCategoriesToPrices.Add(TicketCategories.VIP, 4000);
			clubEvent.TicketCategoriesToPrices.Add(TicketCategories.Simple, 2000);
			clubEvent.TicketCategoriesToPrices.Add(TicketCategories.EnterOnly, 400); 
		}

		[Test]
		public void AddEventWithRequiredData ()
		{
			var adminService = new AdminService();

			adminService.AddEvent(clubEvent);

			Assert.Contains(clubEvent, adminService.GetAllEvents());
		}

		[Test]
		[TestCase(null)]
		[TestCase("")]
		public void AddEvenWithNullTitleValidationFailed(string title)
		{
			var adminService = new AdminService();
			clubEvent.Title = title;

			Assert.Throws<ArgumentOutOfRangeException>(
				delegate 
				{ 
					adminService.AddEvent(clubEvent);
				}
			);
		}

		[Test]
		public void AddEvenWithNullArtistsValidationFailed()
		{
			var adminService = new AdminService();
			clubEvent.Artists = null;

			Assert.Throws<ArgumentNullException>(
				delegate
				{
					adminService.AddEvent(clubEvent);
				}
			);
		}

		[Test]
		public void AddEvenWithEmptyArtistsValidationFailed()
		{
			var adminService = new AdminService();
			clubEvent.Artists = new List<string>();

			Assert.Throws<ArgumentOutOfRangeException>(
				delegate
				{
					adminService.AddEvent(clubEvent);
				}
			);
		}

		[Test]
		public void AddEvenWithoutVipPriceValidationFailed()
		{
			var adminService = new AdminService();
            clubEvent.TicketCategoriesToPrices.Add(TicketCategories.VIP, 0);

			Assert.Throws<ArgumentOutOfRangeException>(
				delegate
				{
					adminService.AddEvent(clubEvent);
				}
			);
		}

		[Test]
		public void AddEvenWithoutTablePriceValidationFailed()
		{
			var adminService = new AdminService();
            clubEvent.TicketCategoriesToPrices.Add(TicketCategories.Simple, 0);

			Assert.Throws<ArgumentOutOfRangeException>(
				delegate
				{
					adminService.AddEvent(clubEvent);
				}
			);
		}

		[Test]
		public void AddEvenWithoutCheapestPriceValidationFailed()
		{
			var adminService = new AdminService();
            clubEvent.TicketCategoriesToPrices.Add(TicketCategories.EnterOnly, 0); 

			Assert.Throws<ArgumentOutOfRangeException>(
				delegate
				{
					adminService.AddEvent(clubEvent);
				}
			);
		}

		[Test]
		public void AddEvenDateInPastValidationFailed()
		{
			var adminService = new AdminService();
			clubEvent.DateAndTime = DateTime.Now.AddDays(-1);

			Assert.Throws<ArgumentOutOfRangeException>(
				delegate
				{
					adminService.AddEvent(clubEvent);
				}
			);
		}

		[Test]
		public void AddEvenDateTodayValidationFailed()
		{
			var adminService = new AdminService();
			clubEvent.DateAndTime = DateTime.Today;

			Assert.Throws<ArgumentOutOfRangeException>(
				delegate
				{
					adminService.AddEvent(clubEvent);
				}
			);
		}

		[Test]
		public void AddEven_SameDateSameTitle_ValidationFailed()
		{
			var adminService = new AdminService();
			adminService.AddEvent(clubEvent);

			Assert.Throws<ArgumentOutOfRangeException>(
				delegate
				{
					adminService.AddEvent(clubEvent);
				}
			);
		}

		[Test]
		public void AddEven_SameDateDifferentTitle()
		{
			throw new NotImplementedException();
		}
	}
}