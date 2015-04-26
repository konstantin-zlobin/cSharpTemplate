using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace cSharpTemplate
{
    [TestFixture]
    public class ClubEventTests
    {
        [Test]
        public void Date_Test()
        {
            var concertDate = new DateTime(2015, 5, 1, 18, 0, 0);

            var club_event = new ClubEvent();
            club_event.Date = concertDate;

            Assert.AreEqual(club_event.Date, concertDate.Date);
        }

        [Test]
        public void Time_Test()
        {
            var concertDate = new DateTime(2015, 5, 1, 18, 0, 0);

            var club_event = new ClubEvent();
            club_event.Time = concertDate;

            Assert.AreEqual(club_event.Time.Hour, concertDate.Hour);
            Assert.AreEqual(club_event.Time.Minute, concertDate.Minute);
            Assert.AreEqual(club_event.Time.Second, concertDate.Second);
        }

        [Test]
        public void Performers_Test()
        {
            var performers = new List<string>();
            performers.Add("Robbie Williams");
            performers.Add("Metallica");
            performers.Add("Scorpions");

            var club_event = new ClubEvent();
            club_event.Performers = performers;

            Assert.AreEqual(club_event.Performers, performers);
        }

        [Test]
        public void AddPrice_Test()
        {
            var club_event = new ClubEvent();
            var category = TicketCategory.VIP;
            var price = 1000;
            club_event.PriceList.Add(category, price);

            decimal actualPrice;
            club_event.PriceList.TryGetValue(category, out actualPrice);
            Assert.AreEqual(actualPrice, price);
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
    }
}