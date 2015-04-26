using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Collections.Generic;

namespace cSharpTemplate
{
    [TestFixture]
    public class ClubEventTest
    {
        ClubEvent clubEvent;

        [SetUp]
        public void InitClubEvent()
        {
            clubEvent = new ClubEvent();
            clubEvent.Title = "Megashow 12345";
            clubEvent.DateAndTime = DateTime.Now.AddDays(2);
            clubEvent.Artists = new List<string> { "Volodya", "Oleg" };
            clubEvent.TicketCategoriesToPrices = new Dictionary<TicketCategories, decimal>();
            clubEvent.TicketCategoriesToPrices.Add(TicketCategories.VIP, 4000);
            clubEvent.TicketCategoriesToPrices.Add(TicketCategories.Simple, 2000);
            clubEvent.TicketCategoriesToPrices.Add(TicketCategories.EnterOnly, 400);
        }

        [Test]
        public void TicketsCreationTest()
        {
            Assert.IsFalse(clubEvent.Tickets.Any(t => t.Status == TicketStatus.Sold));

            Assert.IsTrue(clubEvent.Tickets.Count(t => t.Category == TicketCategories.EnterOnly) == 100);
        }

        [Test]
        public void TicketsBookTest()
        {
            var ticket = clubEvent.BookTicket(100, "Ivan Ivanov");

            Assert.AreEqual(TicketStatus.Booked, ticket.Status);
        }

        [Test]
        public void TicketsBuyTestWithoutBooking()
        {  
            Assert.Throws<Exception>(
                delegate
                {
                    var ticket = clubEvent.BuyTicket(100, "Ivan Ivanov");
                });
        }

        [Test]
        public void TicketsBuyBookedTest()
        {
            var ticket = clubEvent.BookTicket(100, "Ivan Ivanov");
            clubEvent.BuyTicket(ticket.ID, "Ivan Ivanov");

            Assert.AreEqual(TicketStatus.Sold, ticket.Status);
        }

        [Test]
        public void TicketsBuyBooked_Exception_Test()
        {
            var ticket = clubEvent.BookTicket(100, "Peter Petrov");

            Assert.Throws<Exception>(
                delegate {
                   clubEvent.BuyTicket(ticket.ID, "Ivan Ivanov");
                }
                );
        }
    }
}
