using System;

namespace cSharpTemplate
{
    public class Ticket
    {
        public int ID { get; set; }
        public TicketCategories Category { get; set; }
        public TicketStatus Status { get; set; }
        public string BuyerName { get; set; }
        public DateTime BookingDate { get; set; }

        public DateTime BookingExpiredDate
        {
            get { return BookingDate.AddMinutes(30); }
        }

        public Ticket()
        {
            Status = TicketStatus.Free;
        }
    }
}
