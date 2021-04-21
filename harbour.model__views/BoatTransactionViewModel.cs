using System;

namespace harbour.model__views
{
    public class BoatTransactionViewModel
    {
        public int Id { get; set; }
        public TimeSpan ArrivalTimeAtOpenSea  { get; set; }
        public TimeSpan DepartureTimeAtOpenSea  { get; set; }
        public TimeSpan ArrivalTimeAtHarbour  { get; set; }
        public DateTime TransactionDate  { get; set; }
        public string Reference { get; set; }
    }
}