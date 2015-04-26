using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cSharpTemplate
{
	class EventsTickets
	{
		public int EnterySold { get; private set; }


		//public EventsTickets(int entery)
		//{
		//	if (entery < 1)
		//		throw new ArgumentOutOfRangeException("Tickets amouts must be defined");

		//	EnteryTotal = entery;
		//	EnterySold = 0;
		//}

		public void SellEntery()
		{
			EnterySold++;
		}

	}
	
	class CashierService
	{
		Dictionary<ClubEvent, EventsTickets> eventTickets = new Dictionary<ClubEvent, EventsTickets>();

		readonly int EnteryTotal;

		public CashierService(int entery)
		{
			EnteryTotal = entery;
		}
		
		internal bool Sell(ClubEvent clubEvent, PriceCategory priceCategory)
		{
			EventsTickets tickets;
			if (!eventTickets.TryGetValue(clubEvent, out tickets))
			{
				tickets = new EventsTickets();
				eventTickets.Add(clubEvent, tickets);
			}

			if (tickets.EnterySold < EnteryTotal)
			{
				tickets.SellEntery();
				return true;
			}

			return false;
		}
	}
}
