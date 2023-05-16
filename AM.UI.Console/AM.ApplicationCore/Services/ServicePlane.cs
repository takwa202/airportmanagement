using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class ServicePlane : Service<plane>, IServicePlane
    {
        public ServicePlane(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public void DeletePlanes()
        {
            Delete(p=>p.ManifactureDate.AddYears(10).Year<DateTime.Now.Year);
        }

        public IList<Flight> GetFlights(int n)
        {
            return GetAll().OrderByDescending(p=>p.planeID).Take(n).SelectMany(p=>p.Flights).OrderBy(f=>f.FlightDate).ToList();
        }

        public IList<Passenger> GetPassenger(plane p)
        {
            return GetById(p.planeID).Flights.SelectMany(f=>f.Tickets.Select(t=>t.passenger)).ToList();
        }

        public bool IsAvailablePlane(Flight f, int n)
        {
            //int capacity = Get(p => p.Flights.Contains(f) == true).Capacity;
            int capacity = f.Plane.Capacity;
            int nbPassengers = f.Tickets.Count();
            //return ;
            return capacity >= (nbPassengers + n);
        }


        //public void Add(plane p)
        //{
        //    unitOfWork.Repository<plane>().Add(p);

        //}
        //public void Update(plane p)
        //{
        //    unitOfWork.Repository<plane>().Update(p);
        //}
        //public IList<plane> GetAll()
        //{
        //    return unitOfWork.Repository<plane>().GetAll().ToList();
        //}

        ////public IList<plane> GetAll()
        ////{
        ////    return _repo.planes.ToList();  
        ////}

        //public void Remove(plane p)
        //{
        //    unitOfWork.Repository<plane>().Delete(p);   
        //}


    }
}
