using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain

{
    public enum PlaneType { Boing, Airbus }
    public class plane

    {
        [Range(0, int.MaxValue)]  
        public int Capacity { get; set; }
        public DateTime ManifactureDate { get; set; }
        public int planeID { get; set; }
        public PlaneType PlaneType { get; set; }
        public virtual ICollection<Flight> Flights { get; set; }
        //public plane(PlaneType pt, int capacity, DateTime date)
        //{
        //    PlaneType = pt;
        //    capacity = capacity;
        //    ManifactureDate = date;
        //}

        //public plane()
        //{
        //}
        [NotMapped]
        public string Information
        {
            get
            {
                return planeID + " " + ManifactureDate + " " +Capacity;
            }
        }
    }   

}
