using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace cSharpTemplate
{
	[TestFixture]
	class CashierServiceTests
	{
		const int EnteryTickersTotal = 3;
		ClubEvent _event;

		[SetUp]
		public void InitEvent()
		{
			_event = new ClubEvent();
			_event.Title = "New Year Party";
			_event.EventDateTime = DateTime.Now.AddMonths(1);
			_event.Artists = new System.Collections.Generic.List<string>() {"Bill", "Jobs"};
			_event.TicketPrices = new Dictionary<PriceCategory, decimal>
				{
					{PriceCategory.VIP, 1000}, 
					{PriceCategory.Table, 700},
					{PriceCategory.Entery, 500}
				};
		}

		[Test]
		public void SellEnteryTicket()
		{
			CashierService cashier = new CashierService(EnteryTickersTotal);
			Assert.IsTrue(cashier.Sell(_event, PriceCategory.Entery));
		}

		[Test]
		public void SellExtraEnteryTicket()
		{
			CashierService cashier = new CashierService(EnteryTickersTotal);
			for(int i=0; i < EnteryTickersTotal; i++)
				cashier.Sell(_event, PriceCategory.Entery);

			Assert.IsFalse(cashier.Sell(_event, PriceCategory.Entery));
		}

		//[Test]
		//public void SellTableTicket()
		//{
		//	CashierService cashier = new CashierService();
		//	cashier.Sell(PriceCategory.Entery);
		//}

		//[Test]
		//public void SellVIPTicket()
		//{
		//	CashierService cashier = new CashierService();
		//	cashier.Sell(PriceCategory.Entery);
		//}
	}
}
