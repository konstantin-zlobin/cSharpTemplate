using System;
using System.Collections.Generic;
using System.Linq;

namespace cSharpTemplate
{
    public class ClubConcert
    {
        private const int VipSeatsCount = 10;
        private const int SimpleSeatsCount = 25;
        private const int EnterOnlySeatsCount = 100;

        public string Title { get; private set; }
        public DateTime DateAndTime { get; private set; }
        public List<string> SingersList { get; private set; }

        public Dictionary<TicketCategory, decimal> TicketCategoryPrice { get; set; }

        private Dictionary<TicketCategory, List<Seat>> _seats = new Dictionary<TicketCategory, List<Seat>>();


        public ClubConcert(string title, DateTime dateAndTime, List<string> singersList, Dictionary<TicketCategory, decimal> ticketCategoryPrice)
        {
            Title = title;
            DateAndTime = dateAndTime;
            SingersList = singersList;
            TicketCategoryPrice = ticketCategoryPrice;

            InitializeSeats();
        }

        private void InitializeSeats()
        {
            var vipList = new List<Seat>();
            for (int i = 0; i < VipSeatsCount; i++)
            {
                vipList.Add(new Seat { Number = i + 1, Sold = false });
            }

            _seats.Add(TicketCategory.VIP, vipList);

            var simpleList = new List<Seat>();
            for (int i = 0; i < SimpleSeatsCount; i++)
            {
                simpleList.Add(new Seat { Number = i + 1, Sold = false });
            }

            _seats.Add(TicketCategory.Simple, simpleList);

            var enterOnlyList = new List<Seat>();
            for (int i = 0; i < EnterOnlySeatsCount; i++)
            {
                enterOnlyList.Add(new Seat { Number = i + 1, Sold = false });
            }

            _seats.Add(TicketCategory.EnterOnly, enterOnlyList);
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

        public int GetAvailableTicketsCount(TicketCategory ticketCategory)
        {
            return _seats[ticketCategory].Count;
        }

        public Seat GetFreeTicket(TicketCategory ticketCategory, int? number)
        {
            Seat availableSeat;
            if (number.HasValue)
            {
                availableSeat = _seats[ticketCategory].FirstOrDefault(seat => !seat.Sold && seat.Number == number);
            }
            else
            {
                availableSeat = _seats[ticketCategory].FirstOrDefault(seat => !seat.Sold);
            }
            return availableSeat;
        }
    }
}

