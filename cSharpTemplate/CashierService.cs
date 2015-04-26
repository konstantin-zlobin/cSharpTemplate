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

		public bool[] VipSold { get; private set; }

		public EventsTickets(int vipCount)
		{
			VipSold = new bool[vipCount];
		}

		public void SellEntery()
		{
			EnterySold++;
		}

		public bool SellVIP(int i)
		{
			if (i >= VipSold.Length)
			{
				return false;
			}

			if (!VipSold[i])
			{
				VipSold[i] = true;
				return true;
			}
			return false;
		}
	}
	
	class CashierService
	{
		Dictionary<ClubEvent, EventsTickets> eventTickets = new Dictionary<ClubEvent, EventsTickets>();

		readonly int EnteryTotal;
		readonly int VipTotal;

		public CashierService(int entery, int vipTotal)
		{
			EnteryTotal = entery;
			VipTotal = vipTotal;
		}
		
		internal bool Sell(ClubEvent clubEvent, PriceCategory priceCategory)
		{
			EventsTickets tickets;
			if (!eventTickets.TryGetValue(clubEvent, out tickets))
			{
				tickets = new EventsTickets(VipTotal);
				eventTickets.Add(clubEvent, tickets);
			}

			if (tickets.EnterySold < EnteryTotal)
			{
				tickets.SellEntery();
				return true;
			}

			return false;
		}

		internal bool SellVIP(ClubEvent clubEvent, int i)
		{
			EventsTickets tickets;
			if (!eventTickets.TryGetValue(clubEvent, out tickets))
			{
				tickets = new EventsTickets(VipTotal);
				eventTickets.Add(clubEvent, tickets);
			}

//			if (tickets.EnterySold < EnteryTotal)
				return tickets.SellVIP(i);

			return false;
			
		}
	}
}
