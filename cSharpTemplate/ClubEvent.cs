using System;
using System.Collections.Generic;
using System.Linq;

namespace cSharpTemplate
{
	public class ClubEvent
	{
        public Guid ID { get; set; }

        public String Title {get; set;}
		public DateTime DateAndTime { get; set; }
		public List<string> Artists { get; set; }

        public Dictionary<TicketCategories, decimal> TicketCategoriesToPrices { get; set; }

        public List<Ticket> Tickets { get; set; }

        private static int vipCount = 10;
        private static int simpleCount = 25;
        private static int enterCount = 100;
       
		public ClubEvent()
		{
            ID = Guid.NewGuid();
            Tickets = new List<Ticket>(vipCount+simpleCount+enterCount);
            for (int i = 0; i < vipCount; i++)
            {
                Tickets.Add(new Ticket() { ID = i, Category = TicketCategories.VIP });
            }
            var index = Tickets.Count;
            for (int i = index; i < index + simpleCount; i++)
            {
                Tickets.Add(new Ticket() { ID = i, Category = TicketCategories.Simple });
            }
            index = Tickets.Count;
            for (int i = index; i < index + enterCount; i++)
            {
                Tickets.Add(new Ticket() { ID = i, Category = TicketCategories.EnterOnly });
            }

		}

        public Ticket BookTicket(TicketCategories category, string buyerName)
	    {
            var ticketToBook = Tickets.FirstOrDefault(t => t.Category == category && (t.Status == TicketStatus.Free|| (t.Status == TicketStatus.Booked && t.BookingExpiredDate < DateTime.Now)));

            if (ticketToBook != null)
            {
                ticketToBook.Status = TicketStatus.Booked;
                ticketToBook.BookingDate = DateTime.Now;
                ticketToBook.BuyerName = buyerName;
            }
            else
                throw new Exception(String.Format("There are no tickets of {0} category available for booking", category));
            return ticketToBook;
        }

        public Ticket BookTicket(int id, string buyerName)
        {
            var ticketToBook = Tickets.FirstOrDefault(t => t.ID == id);

            if (ticketToBook != null)
                if (ticketToBook.Status == TicketStatus.Free || (ticketToBook.Status == TicketStatus.Booked && ticketToBook.BookingExpiredDate < DateTime.Now))
                {
                    ticketToBook.Status = TicketStatus.Booked;
                    ticketToBook.BookingDate = DateTime.Now;
                    ticketToBook.BuyerName = buyerName;
                }
                else
                    throw new Exception(String.Format("Ticket ID {0} is already booked or sold", id));
            else
                throw new Exception(String.Format("Ticket ID {0} is not found", id));
            return ticketToBook;
        }

        public Ticket BuyTicket(int id, string buyerName)
        {
            var ticketToSell = Tickets.FirstOrDefault(t => t.ID == id && buyerName == t.BuyerName);

            if (ticketToSell != null)
                if (ticketToSell.Status == TicketStatus.Booked)
                    ticketToSell.Status = TicketStatus.Sold;
                else
                    throw new Exception(String.Format("Ticket ID {0} is already sold", id));
            else
                throw new Exception(String.Format("Ticket ID {0} is not found", id));
            return ticketToSell;
        }
	}
}
