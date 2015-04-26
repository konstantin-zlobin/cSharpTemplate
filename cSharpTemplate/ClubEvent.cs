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

        public void SellTicket(TicketCategories category)
        {
            var ticketToSell = Tickets.FirstOrDefault(t => t.Category == category && t.IsSold != true);

            if (ticketToSell != null)
                ticketToSell.IsSold = true;
            else
                throw new Exception(String.Format("There are no tickets of {0} category available", category));
        }

        public void SellTicket(int id)
        {
            var ticketToSell = Tickets.FirstOrDefault(t => t.ID == id);

            if (ticketToSell != null)
                if (!ticketToSell.IsSold)
                    ticketToSell.IsSold = true;
                else
                    throw new Exception(String.Format("Ticket ID {0} is already sold", id));
            else
                throw new Exception(String.Format("Ticket ID {0} is not found", id));    
                
        }
		
		 
    
        //public int CheapestPrice { get; set; }
        //public int TablePrice { get; set; }
        //public int VipPrice { get; set; }

        
	}

    public enum TicketCategories
    {
        VIP,
        Simple,
        EnterOnly
    }
}

