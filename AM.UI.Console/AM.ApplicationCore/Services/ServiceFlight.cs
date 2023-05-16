using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class ServiceFlight : Service<Flight>,  IServiceFlight
    {
        public ServiceFlight(IUnitOfWork unitOfWork):base(unitOfWork) { }

        //public void Add(Flight p)
        //{
        //    unitOfWork.Repository<Flight>().Add(p);
        //}
        //public void Update(Flight p)
        //{
        //    unitOfWork.Repository<Flight>().Update(p);
        //}

        //public IList<Flight> GetAll()
        //{
        //    return unitOfWork.Repository<Flight>().GetAll().ToList();
        //}

        //public void Remove(Flight p)
        //{
        //    unitOfWork.Repository<Flight>().Delete(p);
        //}


    }
}
