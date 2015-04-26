using System;

namespace cSharpTemplate
{
	using NUnit.Framework;

	[TestFixture]
	public class AdminServiceTest
	{
		ClubEvent _clubEvent;

		[SetUp]
		public void InitClubEvent()
		{
			_clubEvent = new ClubEvent();
			_clubEvent.Title = "Megashow 12345";
			_clubEvent.DateTime = DateTime.Now.AddDays(2);
			_clubEvent.Artists = new[] { "Volodya", "Oleg" };
			_clubEvent.VipPrice = 4000;
			_clubEvent.TablePrice = 2000;
			_clubEvent.CheapestPrice = 400;
		}

		[Test]
		public void AddEventWithRequiredData ()
		{
			var adminService = new AdminService();

			adminService.AddEvent(_clubEvent);

			Assert.Contains(_clubEvent, adminService.GetAllEvents());
		}

		[Test]
		[TestCase(null)]
		[TestCase("")]
		public void AddEvenWithNullTitleValidattionFailed(string title)
		{
			var adminService = new AdminService();
			_clubEvent.Title = title;

			Assert.Throws<ArgumentOutOfRangeException>(
				delegate 
				{ 
					adminService.AddEvent(_clubEvent);
				}
			);
		}

		[Test]
		public void AddEvenWithNullArtistsValidattionFailed()
		{
			var adminService = new AdminService();
			_clubEvent.Artists = null;

			Assert.Throws<ArgumentNullException>(
				delegate
				{
					adminService.AddEvent(_clubEvent);
				}
			);
		}

		[Test]
		public void AddEvenWithEmptyArtistsValidattionFailed()
		{
			var adminService = new AdminService();
			_clubEvent.Artists = new string[] {};

			Assert.Throws<ArgumentOutOfRangeException>(
				delegate
				{
					adminService.AddEvent(_clubEvent);
				}
			);
		}

		[Test]
		public void AddEvenWithoutVipPriceValidattionFailed()
		{
			var adminService = new AdminService();
			_clubEvent.VipPrice = 0;

			Assert.Throws<ArgumentOutOfRangeException>(
				delegate
				{
					adminService.AddEvent(_clubEvent);
				}
			);
		}

		[Test]
		public void AddEvenWithoutTablePriceValidattionFailed()
		{
			var adminService = new AdminService();
			_clubEvent.TablePrice = 0;

			Assert.Throws<ArgumentOutOfRangeException>(
				delegate
				{
					adminService.AddEvent(_clubEvent);
				}
			);
		}

		[Test]
		public void AddEvenWithoutCheapestPriceValidattionFailed()
		{
			var adminService = new AdminService();
			_clubEvent.CheapestPrice = 0;

			Assert.Throws<ArgumentOutOfRangeException>(
				delegate
				{
					adminService.AddEvent(_clubEvent);
				}
			);
		}

		[Test]
		public void AddEvenDateInPastValidattionFailed()
		{
			var adminService = new AdminService();
			_clubEvent.DateTime = DateTime.Now.AddDays(-1);

			Assert.Throws<ArgumentOutOfRangeException>(
				delegate
				{
					adminService.AddEvent(_clubEvent);
				}
			);
		}

		[Test]
		public void AddEvenDateTodayValidattionFailed()
		{
			var adminService = new AdminService();
			_clubEvent.DateTime = DateTime.Today;

			Assert.Throws<ArgumentOutOfRangeException>(
				delegate
				{
					adminService.AddEvent(_clubEvent);
				}
			);
		}

		[Test]
		public void AddEven_SameDateSameTitle_ValidattionFailed()
		{
			var adminService = new AdminService();
			adminService.AddEvent(_clubEvent);

			Assert.Throws<ArgumentOutOfRangeException>(
				delegate
				{
					adminService.AddEvent(_clubEvent);
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