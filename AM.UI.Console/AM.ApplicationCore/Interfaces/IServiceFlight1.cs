using AM.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Interfaces
{
    public interface IServiceFlight1 
    {
        List<DateTime> GetFlightDates(string destination);
        public void GetFlights(string filterType, string filterValue);
        public void ShowFlightDetails(plane p);
        public IEnumerable<DateTime> GetFlightdates(string Destination);
        public int ProgrammedFlightNumber(DateTime startDate);
        public double DurationAverage(string Destination);
        public IEnumerable<Flight> OrderedDurationFlights();
        public IEnumerable<Traveller> SeniorTravellers(Flight flight);
        public void DestinationGroupedFlights();

    }
}















