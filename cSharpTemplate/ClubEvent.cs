using System;

namespace cSharpTemplate
{
	public class ClubEvent
	{
		public ClubEvent()
		{
			DateTime = DateTime.MinValue;
		}
		
		public String Title {get; set;}
		public DateTime DateTime { get; set; }
		public string[] Artists { get; set; }

		public int CheapestPrice { get; set; }
		public int TablePrice { get; set; }
		public int VipPrice { get; set; }
	}
}

