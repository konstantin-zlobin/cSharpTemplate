using System;
using System.Collections.Generic;

namespace cSharpTemplate
{
	public class AdminService
	{
		private readonly List<ClubConcert> club_events;

		public AdminService ()
		{
			club_events = new List<ClubConcert> ();
		}

		public void AddEvent(ClubConcert club_event) 
		{
            var errorsList = club_event.GetConcertValidationErrorsList();
            if (errorsList.Count != 0)
            {
				throw new Exception ("validation failed: " + String.Join(@"\n\r", errorsList));
			}
			club_events.Add (club_event);
		}

		public List<ClubConcert> GetAllEvents() {
			return club_events;
		}

        public Seat SellTicket(ClubConcert clubConcert, TicketCategory ticketCategory, string buyerFIO, int? seatNumber = null)
        {
            Seat seat = clubConcert.GetReservedTicket(ticketCategory, buyerFIO, seatNumber);

            if (seat != null)
            {
                seat.Sold = true;
            }
            else
            {
                throw new Exception("Ticket not exists or already sold.");
            }

            return seat;
        }

	    public Seat SellTicket(ClubConcert clubConcert, TicketCategory ticketCategory, int? seatNumber = null)
	    {
            Seat seat = clubConcert.GetFreeTicket(ticketCategory, seatNumber);

	        if (seat != null)
	        {
	            seat.Sold = true;
	        }
	        else
	        {
	           throw new Exception("Ticket not exists or already sold.");
	        }

	        return seat;
	    }

        public void ReserveTicket(ClubConcert clubConcert, TicketCategory ticketCategory, int transactionID, string buyerFIO, int? seatNumber = null)
        {
            if (string.IsNullOrWhiteSpace(buyerFIO))
                throw new Exception("FIO must not be empty");

            Seat seat = clubConcert.GetFreeTicket(ticketCategory, seatNumber);

            if (seat != null)
            {
                seat.TransactionID = transactionID;
                seat.ReserveTime = DateTime.Now;
                seat.BuyerFIO = buyerFIO;
            }
            else
            {
                throw new Exception("This ticket was reserved.");
            }
        }
	}
}

