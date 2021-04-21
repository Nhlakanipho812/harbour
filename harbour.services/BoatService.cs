using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using harbour.helpers;
using harbour.model__views;
using harbour.models;

namespace harbour.services
{
    public class BoatService : IBoatService
    {
        private readonly HarbourDb _db;
        private const int Perimeter = 10;

        public BoatService(HarbourDb db)
        {
            _db = db;
        }

        private IEnumerable<TransactionViewModel> GenerateBoats()
        {
            var boats = _db.Boat.ToList();
            var rng = new Random();
            var length = rng.Next(15);
            var results = new List<TransactionViewModel>();
            
            //transact the boat movements
            var recordCode = Guid.NewGuid().ToString().Substring(0, 9);
            foreach (var boat in boats)
            {
                for (var i = 0; i < length; i++)
                {
                    var random = new Random();
                    //simulate the arrival time
                    Thread.Sleep(random.Next(1000, 10000)); // 1 second to 10 s
                    var i2 = i;

                    var arrivalTimeAtOpenSea = DateTime.Now.TimeOfDay;

                    //the task waits for another task to finish before it starts.
                    Task.Run(() =>
                    {
                        GetBoat(new Boat {Id = i2, Name = boat.Name, Speed = boat.Speed}, arrivalTimeAtOpenSea,
                            recordCode, out var model);
                        results.Add(model);
                    }).Wait();
                }
            }

            //Task.WaitAll();

            return results;
        }

        private void GetBoat(Boat boat, TimeSpan arrivalTimeAtOpenSea, string recordCode , out TransactionViewModel model)
        {
            //calculate time and convert it to milliseconds where 3600 is seconds in an hour and 1000 is milliseconds in a millisecond
            var hours = Perimeter / (double) boat.Speed;
            var seconds = hours * 3600;
            var milliSeconds = seconds * 10;

            var departureTimeAtOpenSea = DateTime.Now.TimeOfDay;

            //task 1 stops
            Thread.Sleep(Convert.ToInt32(Math.Round(milliSeconds, 0)));
            var arrivalTimeAtHarbour = DateTime.Now.TimeOfDay;


            var transaction = new BoatTransaction
            {
                ArrivalTimeAtHarbour = arrivalTimeAtHarbour,
                ArrivalTimeAtOpenSea = arrivalTimeAtOpenSea,
                DepartureTimeAtOpenSea = departureTimeAtOpenSea,
                Reference = Guid.NewGuid().ToString().Substring(0, 7) + "-" + boat.Id,
                TransactionDate = DateTime.Now,
                RecordCode = recordCode,
                Name = boat.Name
            };

            _db.BoatTransaction.Add(transaction);
            _db.SaveChanges();

            model = new TransactionViewModel
            {
                Id = transaction.Id,
                BatchNumber = transaction.RecordCode,
                TransactionDate = transaction.TransactionDate,
                ArrivalTimeAtHarbour = $"arrived at harbour at {ConvertTimeSpan(transaction.ArrivalTimeAtHarbour)} ",
                ArrivalTimeAtOpenSea = $"arrived at open sea at {ConvertTimeSpan(transaction.ArrivalTimeAtOpenSea)}" ,
                DepartureTimeAtOpenSea = $"departed open sea at {ConvertTimeSpan(transaction.DepartureTimeAtOpenSea)}",
                BoatName = $"{transaction.Name}-{transaction.Reference}",
                TimeTaken = $"Took {ConvertTimeSpan(transaction.ArrivalTimeAtHarbour - transaction.DepartureTimeAtOpenSea)} to get to the harbour"
            };
        }


        public ResponseViewModel<List<TransactionViewModel>> SchedulingEngine()
        {
            try
            {
                using (_db)
                {
                    return new ResponseViewModel<List<TransactionViewModel>>
                    {
                        Code = 200,
                        Data = GenerateBoats().ToList(),
                        Errors = null,
                        Message = "successfully completed the trial"
                    };
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private static string ConvertTimeSpan(TimeSpan timeSpan)
        {
            return $"{timeSpan.Hours:D2}h:{timeSpan.Minutes:D2}m:{timeSpan.Seconds:D2}s";
        }

        public ResponseViewModel<List<TransactionViewModel>> GetAllTransactions()
        {
            try
            {
                using (_db)
                {
                    var res = _db.BoatTransaction.ToList().Select(s => new TransactionViewModel
                    {
                        Id = s.Id,
                        BatchNumber = s.RecordCode,
                        TransactionDate = s.TransactionDate,
                        ArrivalTimeAtHarbour = $"{s.Name}-{s.Reference} arrived at harbour at {ConvertTimeSpan(s.ArrivalTimeAtHarbour)} ",
                        ArrivalTimeAtOpenSea = $"{s.Name}-{s.Reference} arrived at open sea at {ConvertTimeSpan(s.ArrivalTimeAtOpenSea)}" ,
                        DepartureTimeAtOpenSea = $"{s.Name}-{s.Reference} departed open sea at {ConvertTimeSpan(s.DepartureTimeAtOpenSea)}"
                    }).ToList();
                    return new ResponseViewModel<List<TransactionViewModel>>
                    {
                        Code = 200,
                        Data = res,
                        Errors = null,
                        Message = "Success"
                    };
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}