// See https://aka.ms/new-console-template for more information
using Am.Infrastructure;
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Services;

////Console.WriteLine("Hello, World!");
////plane p1 = new plane();
////p1.Capacity = 200;
////p1.PlaneID = 1;
////p1.ManifactureDate = new DateTime(2023, 02, 02);
////p1.PlaneType = PlaneType.Boing;
////plane p2 = new plane(PlaneType.Airbus, 200, new DateTime(2023, 02, 02));
//plane p3 = new plane()
//{
//    PlaneType = PlaneType.Boing,
//    Capacity = 1,
//    ManifactureDate = DateTime.Now
//};
//Passenger passenger1 = new Passenger()
//{
//    FullName=new FullName
//    {
//        FirstName = "oussama",
//        LastName = "lachiheb",
//    },
//    EmailAddress = "abc@gmail.com"
//};
////Console.WriteLine(passenger1.CheckProfile("hgt", "bgh", "abc@gmail.com"));
//Traveller traveller1 = new Traveller()
//{
//    FullName = new FullName
//    {
//        FirstName = "oussama",
//        LastName = "lachiheb",
//    },
//    EmailAddress = "abc2@gmail.com"
//};
//Staff st1 = new Staff()
//{
//    FullName = new FullName { FirstName = "oussama", LastName = "lachiheb" },
//    EmailAddress = "abc3@gmail.com"
//};
////Console.WriteLine("method passengerType for staff");
////st1.PassengerType();
////Console.WriteLine("method passengerType for traveller");
////traveller1.PassengerType();
////Console.WriteLine("method passengerType for passenger");
////passenger1.PassengerType();
//ServiceFlight serviceFlight = new ServiceFlight();
//serviceFlight.Flights = TestData.listFlights;
////foreach (var item in serviceFlight.GetFlightDates("Paris"))
////    Console.WriteLine(item);
////serviceFlight.GetFlights("Destination","Paris");
////foreach (var item in serviceFlight.GetFlightdates("Paris"))
////{
////    Console.WriteLine(item);
////}
////serviceFlight.DestinationGroupedFlights();
////serviceFlight.FlightDetailsDel(TestData.BoingPlane);
////Console.WriteLine(serviceFlight.DurationAverageDel("Paris"));
//Console.WriteLine(passenger1.ToString());
//PassengerExtension.UpperFullName(passenger1);
//Console.WriteLine(passenger1.ToString());
AMContext context = new AMContext();
context.Flights.Add(TestData.flight2);
context.SaveChanges();
Console.WriteLine(context.Flights.First().Plane.Capacity);


