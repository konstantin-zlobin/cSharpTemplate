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
            clubEvent.TicketCategoriesToPrices.Add(TicketCategories.VIP, 4000);
            clubEvent.TicketCategoriesToPrices.Add(TicketCategories.Simple, 2000);
            clubEvent.TicketCategoriesToPrices.Add(TicketCategories.EnterOnly, 400);
        }

        [Test]
        public void TicketsCreationTest()
        {
            Assert.IsFalse(clubEvent.Tickets.Any(t => t.IsSold));

            Assert.IsTrue(clubEvent.Tickets.Count(t => t.Category == TicketCategories.EnterOnly) == 100);
        }

        [Test]
        public void TicketsSellTest()
        {
            Assert.Throws<Exception>(
                delegate
                {
                    clubEvent.SellTicket(136);
                });
        }
    }
}
