using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        [Key]
        [StringLength(7)]
        public string PassportNumber { get; set; }
        [Display(Name ="Date of Birth")]
        [DataType(DataType.DateTime)]
        public DateTime BirthDate { get; set; }
        [DataType(DataType.EmailAddress)]
        //[EmailAddress]
        public string EmailAddress { get; set; }

        public  FullName FullName { get; set; }
        //[DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^[0-9]{8}$")]
        public string TelNumber { get; set; }
        //public ICollection<Flight> Flights { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
        //public bool CheckProfile(string fistname,string lastname)
        //{
        //    return fistname == FirstName && lastname == LastName;

        //}
        //public bool CheckProfile(string fistname, string lastname,string email)
        //{
        //    return fistname == FirstName && lastname == LastName && email == EmailAddress;
        //}
        public bool CheckProfile(string fistname, string lastname, string email = null)
        {
            if (email != null)
            {

                return fistname == FullName.FirstName && lastname == FullName.LastName && email == EmailAddress;
            }
            else
            {
                return fistname == FullName.FirstName && lastname == FullName.LastName;
            }
        }
        public virtual void PassengerType()
        {
            Console.WriteLine("I am a passenger");
        }
        public override string ToString()
        {
            return this.FullName.FirstName + " " + this.FullName.LastName;
        }
    }
   
}
