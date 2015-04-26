using System;

namespace cSharpTemplate
{
    public class Seat
    {
        public int Number { get; set; }
        public bool Sold { get; set; }

        public DateTime ReserveTime { get; set; }

        public int TransactionID { get; set; }

        public DateTime Boughttime { get; set; }

        public string BuyerFIO { get; set; }
    }
}
