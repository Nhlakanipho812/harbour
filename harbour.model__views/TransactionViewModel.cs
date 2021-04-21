using System;

namespace harbour.model__views
{
    public class TransactionViewModel
    {
        public int Id { get; set; }
        public string ArrivalTimeAtOpenSea  { get; set; }
        public string DepartureTimeAtOpenSea  { get; set; }
        public string ArrivalTimeAtHarbour  { get; set; }
        public DateTime TransactionDate  { get; set; }
        public string BatchNumber { get; set; }
        public string BoatName { get; set; }
        public string TimeTaken { get; set; }
    }
}