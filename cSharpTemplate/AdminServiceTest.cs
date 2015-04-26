using System;

namespace cSharpTemplate
{
	using NUnit.Framework;
using System.Collections.Generic;

	[TestFixture]
	public class AdminServiceTest
	{
		[Test]
		public void AddEvent_positive ()
		{
            //var admin_service = new AdminService ();
            //var concert = new ClubConcert ();
            //concert.title = "Megashow 12345";
            //admin_service.AddEvent (club_event);
            //Assert.Contains (club_event, admin_service.GetAllEvents ());
		}

		[Test]
		public void AddEvent_validation_failed ()
		{
			var admin_service = new AdminService ();
            var club_event = InvalidConcertTitle();

			Assert.Throws<Exception>(
				delegate 
				{
					admin_service.AddEvent (club_event);
				}
			);
		}

        
        private DateTime validDateTime = DateTime.UtcNow.AddDays(3);
        private string validTitle = "TestTitle";
        private List<string> validSingersList = new List<string> { "TestSinger1" };
        private Dictionary<TicketCategory, decimal> validTicketCategoryPrice = new Dictionary<TicketCategory, decimal>() { { TicketCategory.EnterOnly, 500 } };

        private ClubConcert InvalidConcertTitle()
        {
            return new ClubConcert("", validDateTime, validSingersList, validTicketCategoryPrice);
        }

        private ClubConcert InvalidConcertDateTime()
        {
            return new ClubConcert(validTitle, DateTime.UtcNow.AddDays(-1), validSingersList, validTicketCategoryPrice);
        }

        [Test]
	    public void ClubConcertAvailableTickets_Test()
        {
            var clubConcert = new ClubConcert("Test Concert", DateTime.Now, new List<string> {"Metallica"},
                validTicketCategoryPrice);

            Assert.AreEqual(10, clubConcert.GetAvailableTicketsCount(TicketCategory.VIP));
            Assert.AreEqual(25, clubConcert.GetAvailableTicketsCount(TicketCategory.Simple));
            Assert.AreEqual(100, clubConcert.GetAvailableTicketsCount(TicketCategory.EnterOnly));
        }
	}
}