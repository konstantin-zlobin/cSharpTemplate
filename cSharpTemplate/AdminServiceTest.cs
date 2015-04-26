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

        [Test]
        public void SellVIPTickets_Test()
        {
            //Add event
            var admin_service = new AdminService();
            var club_event = new ClubEvent();
            club_event.Title = "Megashow 12345";
            club_event.Date = new DateTime(2015, 5, 1, 18, 0, 0); ;
            club_event.Time = new DateTime(2015, 5, 1, 18, 0, 0); ;
            club_event.Performers = new List<string>() { "1" };
            club_event.PriceList.Add(TicketCategory.VIP, 1);
            admin_service.AddEvent(club_event);

            //sell 10 VIP
            for (int i = 0; i < 10; i++)
            {
                admin_service.SellTicket("Megashow 12345", new Ticket() { Category = TicketCategory.VIP, TicketPlace = i + 1 });
            }

            //test 11th VIP ticket
            Assert.Throws<Exception>(
                delegate
                {
                    admin_service.SellTicket("Megashow 12345", new Ticket() { Category = TicketCategory.VIP, TicketPlace = 11 });
                }
            );

            //test sold VIP ticket
            Assert.Throws<Exception>(
                delegate
                {
                    admin_service.SellTicket("Megashow 12345", new Ticket() { Category = TicketCategory.VIP, TicketPlace = 3 });
                }
            );

            //sell 25 Simple
            for (int i = 0; i < 25; i++)
            {
                admin_service.SellTicket("Megashow 12345", new Ticket() { Category = TicketCategory.General, TicketPlace = i + 1 });
            }

            //test 26th Simple ticket
            Assert.Throws<Exception>(
                delegate
                {
                    admin_service.SellTicket("Megashow 12345", new Ticket() { Category = TicketCategory.General, TicketPlace = 26 });
                }
            );

            //test sold Simple ticket
            Assert.Throws<Exception>(
                delegate
                {
                    admin_service.SellTicket("Megashow 12345", new Ticket() { Category = TicketCategory.General, TicketPlace = 10 });
                }
            );

            //sell 100 Entrance
            for (int i = 0; i < 100; i++)
            {
                admin_service.SellTicket("Megashow 12345", new Ticket() { Category = TicketCategory.Entrance });
            }

            //test 101th Simple ticket
            Assert.Throws<Exception>(
                delegate
                {
                    admin_service.SellTicket("Megashow 12345", new Ticket() { Category = TicketCategory.Entrance });
                }
            );
        }

		[Test]
		public void BookTicket_Test()
		{
			var adminService = new AdminService();
			var club_event = new ClubEvent();
			club_event.Title = "Megashow 12345";
			club_event.Date = new DateTime(2015, 5, 1, 18, 0, 0); ;
			club_event.Time = new DateTime(2015, 5, 1, 18, 0, 0); ;
			club_event.Performers = new List<string>() { "1" };
			club_event.PriceList.Add(TicketCategory.VIP, 1);
			adminService.AddEvent(club_event);

			var user = "test user";
			var ticket = new Ticket() { Category = TicketCategory.VIP, User = user, TicketPlace = 1 };

			var booked = adminService.BookTicket(club_event.Title, ticket);

			Assert.IsTrue(booked);

		}

		[Test]
		public void BookTicketAlreadyBooked_Test()
		{
			var adminService = new AdminService();
			var club_event = new ClubEvent();
			club_event.Title = "Megashow 12345";
			club_event.Date = new DateTime(2015, 5, 1, 18, 0, 0); ;
			club_event.Time = new DateTime(2015, 5, 1, 18, 0, 0); ;
			club_event.Performers = new List<string>() { "1" };
			club_event.PriceList.Add(TicketCategory.VIP, 1);
			adminService.AddEvent(club_event);

			var user = "test user";
			var ticket = new Ticket() { Category = TicketCategory.VIP, User = user, TicketPlace = 1 };

			var bookedFirst = adminService.BookTicket(club_event.Title, ticket);

			Assert.IsTrue(bookedFirst);

			var bookedSecond = adminService.BookTicket(club_event.Title, ticket);

			Assert.IsFalse(bookedSecond);
		}

		[Test]
		public void SellBookedTicket_Test()
		{
			var adminService = new AdminService();
			var club_event = new ClubEvent();
			club_event.Title = "Megashow 12345";
			club_event.Date = new DateTime(2015, 5, 1, 18, 0, 0); ;
			club_event.Time = new DateTime(2015, 5, 1, 18, 0, 0); ;
			club_event.Performers = new List<string>() { "1" };
			club_event.PriceList.Add(TicketCategory.VIP, 1);
			adminService.AddEvent(club_event);

			var user = "test user";
			var ticket = new Ticket() { Category = TicketCategory.VIP, User = user, TicketPlace = 1 };

			adminService.BookTicket(club_event.Title, ticket);

			var sold = adminService.SellBookedTicket(club_event.Title, ticket);

			Assert.IsTrue(sold);
		}

		[Test]
		public void SellAnotherBookedTicket_Test()
		{
			var adminService = new AdminService();
			var club_event = new ClubEvent();
			club_event.Title = "Megashow 12345";
			club_event.Date = new DateTime(2015, 5, 1, 18, 0, 0); ;
			club_event.Time = new DateTime(2015, 5, 1, 18, 0, 0); ;
			club_event.Performers = new List<string>() { "1" };
			club_event.PriceList.Add(TicketCategory.VIP, 1);
			adminService.AddEvent(club_event);

			var user = "test user";
			var ticket = new Ticket() { Category = TicketCategory.VIP, User = user, TicketPlace = 1 };

			adminService.BookTicket(club_event.Title, ticket);

			ticket.User = null;

			Assert.Throws<Exception>(
				delegate 
				{ 
			adminService.SellTicket(club_event.Title, ticket);
				});
		}

	}
}
