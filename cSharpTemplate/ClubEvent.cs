using System;
using System.Collections.Generic;

namespace cSharpTemplate
{
	public class ClubConcert
	{
		public string Title {get; private set;}
        public DateTime DateAndTime { get; private set; }
        public List<string> SingersList { get; private set; }

        public Dictionary<TicketCategory, decimal> TicketCategoryPrice { get;  set; }
        
        public ClubConcert(string title, DateTime dateAndTime, List<string> singersList, Dictionary<TicketCategory, decimal> ticketCategoryPrice)
        {
            Title = title;
            DateAndTime = dateAndTime;
            SingersList = singersList;
            TicketCategoryPrice = ticketCategoryPrice;
        }

        public List<string> GetConcertValidationErrorsList()
        {
            var result = new List<string>();
            if (string.IsNullOrWhiteSpace(Title))
                result.Add("Title is empty");

            if (DateAndTime == DateTime.MinValue || DateAndTime <= DateTime.UtcNow || DateAndTime >= DateTime.UtcNow.AddMonths(6))
                result.Add("Date is invalid");

            if (SingersList == null || SingersList.Count == 0)
                result.Add("The list of singers is empty");

            if (TicketCategoryPrice == null || TicketCategoryPrice.Count == 0)
                result.Add("Ticket categories and pricea are empty");

            return result;
        }
	}

    public enum TicketCategory
    {
        VIP,
        Simple,
        EnterOnly
    }
}

