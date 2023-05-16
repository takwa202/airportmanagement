using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class ServiceFlight1 : Service<Flight>, IServiceFlight1
    {
        public List<Flight> Flights => GetAll().ToList();

        public void DestinationGroupedFlights()
        {
            //var query = from flight in Flights
            //            group flight by flight.Destination;
            var queryLambda = Flights.GroupBy(f => f.Destination)
                                    .Select(f => f);
            foreach (var group in queryLambda)
            {
                Console.WriteLine("Destination" + " : " + group.Key);
                foreach (var item in group)
                {
                    Console.WriteLine("Decollage" + " : " + item.FlightDate);
                }
            }
        }

        public double DurationAverage(string Destination)
        {
            //var query = from flight in Flights
            //            where flight.Destination == Destination
            //            select flight.EstimatedDuration;
            //return query.Average();

            var queryLambda = Flights.Where((f) => f.Destination == Destination)
                        .Select(f => f.EstimatedDuration);
            return queryLambda.Average();
        }

        public List<DateTime> GetFlightDates(string destination)
        {
            //List<DateTime> result = new List<DateTime>();
            //for (int i = 0; i < Flights.Count; i++)
            //{
            //    if (Flights[i].Destination == destination)
            //    {
            //        result.Add(Flights[i].FlightDate);
            //    }
            //}
            //return result;
            var queryLambda = Flights.Where(f => f.Destination == destination)
                                     .Select(f => f.FlightDate);
            return queryLambda.ToList();
        }

        public IEnumerable<DateTime> GetFlightdates(string Destination)
        {
            //var query = from flight in Flights
            //            where flight.Destination == Destination
            //            select flight.FlightDate;
            //return query;
            var queryLambda = Flights.Where(f => f.Destination == Destination).Select(f => f.FlightDate);
            return queryLambda.ToList();

        }

        public void GetFlights(string filterType, string filterValue)
        {
            switch (filterType)
            {
                case "Destination":
                    foreach (var item in Flights)
                    {
                        if (item.Destination == filterValue)
                        {
                            Console.WriteLine(item);
                        }
                    }
                    break;
                case "FlightDate":
                    foreach (var item in Flights)
                    {
                        if (item.FlightDate == DateTime.Parse(filterValue))
                        {
                            Console.WriteLine(item);
                        }
                    }
                    break;
                case "Departure":
                    foreach (var item in Flights)
                    {
                        if (item.Departure == filterValue)
                        {
                            Console.WriteLine(item);
                        }
                    }
                    break;
                case "FlightID":
                    foreach (var item in Flights)
                    {
                        if (item.FlightID == int.Parse(filterValue))
                        {
                            Console.WriteLine(item);
                        }
                    }
                    break;

            }

        }

        public IEnumerable<Flight> OrderedDurationFlights()
        {
            //var query = from flight in Flights
            //            orderby flight.EstimatedDuration descending
            //            select flight;
            //return query;
            var queryLambda = Flights.OrderByDescending(f => f.EstimatedDuration);
            return queryLambda.ToList();
        }

     

        public IEnumerable<Traveller> SeniorTravellers(Flight flight)
        {
            //var query = from traveller in flight.Passengers.OfType<Traveller>()
            //            orderby traveller.BirthDate
            //            select traveller;
            //return query.Take(3);
            //var queryLambda = flight.Passengers.OfType<Traveller>().OrderBy(t => t.BirthDate)
            //                .Select(t => t);
            //return queryLambda.ToList();
            return null;
        }

        public void ShowFlightDetails(plane p)
        {
            //var query = from flight in Flights
            //            where flight.Plane == p
            //            select flight;
            var queryLambda = Flights.Where(f => f.Plane == p)
                .Select(f => f);
            foreach (var item in queryLambda)
            {
                Console.WriteLine(item.Destination);
                Console.WriteLine(item.FlightDate);
            }
        }

        public int ProgrammedFlightNumber(DateTime startDate)
        {

            //var query = from f in Flights
            //            where f.FlightDate >= startDate && f.FlightDate <= startDate.AddDays(7)
            //            select f;
            //return query.Count();
            var queryLambda = Flights.Where(f => f.FlightDate >= startDate && f.FlightDate <= startDate.AddDays(7))
                                     .Count();
            return queryLambda;
        }

        public Action<plane> FlightDetailsDel;
        public Func<String, double> DurationAverageDel;


        public ServiceFlight1(IUnitOfWork unitOfWork):base(unitOfWork)
        {
            //FlightDetailsDel = ShowFlightDetails;
            //DurationAverageDel = DurationAverage;
            FlightDetailsDel = p =>
            {
                var query = from flight in Flights
                            where flight.Plane == p
                            select flight;
                foreach (var item in query)
                {
                    Console.WriteLine(item.Destination);
                    Console.WriteLine(item.FlightDate);
                }
            };
            DurationAverageDel = d => {
                var query = from flight in Flights
                            where flight.Destination == d
                            select flight.EstimatedDuration;
                return query.Average();
            };
        }
        



    }
}
