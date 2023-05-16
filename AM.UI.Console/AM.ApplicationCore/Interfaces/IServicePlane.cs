using AM.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Interfaces
{
    public interface IServicePlane : IService<plane>
    {
        //public void Add(plane Plane);
        //public void Update(plane Plane);
        //public void Remove(plane Plane);
        //public IList<plane> GetAll();
        public IList<Passenger> GetPassenger(plane p);
        public IList<Flight>GetFlights(int n);
        public bool IsAvailablePlane(Flight f,int n);
        public void DeletePlanes();
    }
}
