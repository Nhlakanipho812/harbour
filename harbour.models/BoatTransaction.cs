using System;

namespace harbour.models
{
    public class BoatTransaction
    {
        public int Id { get; set; }
        public TimeSpan ArrivalTimeAtOpenSea  { get; set; }
        public TimeSpan DepartureTimeAtOpenSea  { get; set; }
        public TimeSpan ArrivalTimeAtHarbour  { get; set; }
        public DateTime TransactionDate  { get; set; }
        public string Reference { get; set; }
        public string Name { get; set; }
        public string RecordCode { get; set; }
    }
}