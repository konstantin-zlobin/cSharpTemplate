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
		public bool[] TableSold { get; private set; }

		public EventsTickets(int vipCount, int tableCount)
		{
			VipSold = new bool[vipCount];
			TableSold = new bool[tableCount];
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

		public bool SellTable(int i)
		{
			if (i >= TableSold.Length)
			{
				return false;
			}

			if (!TableSold[i])
			{
				TableSold[i] = true;
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
		readonly int TableTotal;

		public CashierService(int entery, int vipTotal, int tableTotal)
		{
			EnteryTotal = entery;
			VipTotal = vipTotal;
			TableTotal = tableTotal;
		}
		
		internal bool Sell(ClubEvent clubEvent, PriceCategory priceCategory)
		{
			EventsTickets tickets;
			if (!eventTickets.TryGetValue(clubEvent, out tickets))
			{
				tickets = new EventsTickets(VipTotal, TableTotal);
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
				tickets = new EventsTickets(VipTotal, TableTotal);
				eventTickets.Add(clubEvent, tickets);
			}

			return tickets.SellVIP(i);
		}

		internal bool SellTable(ClubEvent clubEvent, int i)
		{
			EventsTickets tickets;
			if (!eventTickets.TryGetValue(clubEvent, out tickets))
			{
				tickets = new EventsTickets(VipTotal, TableTotal);
				eventTickets.Add(clubEvent, tickets);
			}

			return tickets.SellTable(i);
		}
	}
}
