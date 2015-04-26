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
		const int EnteryTickersTotal = 100;
		const int VIPTickersTotal = 10;
		const int TableTickersTotal = 25;
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


		private CashierService CreateCashier()
		{
			return new CashierService(EnteryTickersTotal, VIPTickersTotal, TableTickersTotal);
		}

		[Test]
		public void SellEnteryTicket()
		{
			CashierService cashier = CreateCashier();
			Assert.IsTrue(cashier.Sell(_event, PriceCategory.Entery));
		}

		[Test]
		public void SellExtraEnteryTicket()
		{
			CashierService cashier = CreateCashier();
			for(int i=0; i < EnteryTickersTotal; i++)
				cashier.Sell(_event, PriceCategory.Entery);

			Assert.IsFalse(cashier.Sell(_event, PriceCategory.Entery));
		}

		[Test]
		public void SellVIPTicket()
		{
			CashierService cashier = CreateCashier();
			Assert.IsTrue(cashier.SellVIP(_event, 1));
		}

		[Test]
		public void SellExtraVIPTicket()
		{
			CashierService cashier = CreateCashier();
			for (int i = 0; i < VIPTickersTotal; i++)
				cashier.SellVIP(_event, i);

			Assert.IsFalse(cashier.SellVIP(_event, VIPTickersTotal));
		}

		[Test]
		public void SellTableTicket()
		{
			CashierService cashier = CreateCashier();
			Assert.IsTrue(cashier.SellTable(_event, 1));
		}

		[Test]
		public void SellExtraTableTicket()
		{
			CashierService cashier = CreateCashier();
			for (int i = 0; i < TableTickersTotal; i++)
				cashier.SellTable(_event, i);

			Assert.IsFalse(cashier.SellTable(_event, TableTickersTotal));
		}
	}
}
