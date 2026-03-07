using System.Xml.Linq;

namespace Week4Started
{
    class OLADriver
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string  VehicleNo { get; set; }
        public List<Ride> Rides { get; set; }
        public void Display()
        {
            decimal totalFare = 0;
            foreach (Ride item in Rides)
            {
                Console.WriteLine(item);
                totalFare += item.Fare;
            }
            Console.WriteLine($"Total Fare: {totalFare}");
        }
        public override string ToString()
        {
            return $"ID: {Id} | Driver Name: {Name} | Vehicle Number: {VehicleNo} | Rides: {Rides}";
        }
    }
    class Ride
    {
        public int RideId { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public decimal Fare { get; set; }
        public override string ToString()
        {
            return $"ID: {RideId} | From: {From} | To: {To} | Fare: {Fare}";
        }
    }

    internal class DriverRider
    {
        static void Main(string[] args)
        {
            List<Ride> rides = new List<Ride>
            {
                new Ride()
                {
                    RideId = 1,
                    From = "Delhi",
                    To = "Gurgaon",
                    Fare = 250
                },
                new Ride()
                {
                    RideId = 2,
                    From = "Noida",
                    To = "Delhi",
                    Fare = 300
                }
            };
            List<Ride> rides2 = new List<Ride>
            {
                new Ride()
                {
                    RideId = 3,
                    From = "Delhi",
                    To = "Mohali",
                    Fare = 750
                },
                new Ride()
                {
                    RideId = 4,
                    From = "Noida",
                    To = "Gwalior",
                    Fare = 400
                }
            };
            List<OLADriver> drivers = new List<OLADriver>
            {
                new OLADriver
                {
                    Id = 1,
                    Name = "Baalpreet Singh",
                    VehicleNo = "HR-9821",
                    Rides = rides
                },
                new OLADriver
                {
                    Id = 2,
                    Name = "Ramesh Singh",
                    VehicleNo = "PB-1823",
                    Rides = rides2
                }
            };

            foreach (var driver in drivers)
            {
                Console.WriteLine("Driver Details");
                Console.WriteLine("-------------------------");
                Console.WriteLine($"ID        : {driver.Id}");
                Console.WriteLine($"Name      : {driver.Name}");
                Console.WriteLine($"VehicleNo : {driver.VehicleNo}");
                Console.WriteLine("-------------------------");
                Console.WriteLine($"Rides");
                driver.Display();
                Console.WriteLine();

                //Console.WriteLine("Rides:");
                //Console.WriteLine("-------------------------");

                //foreach (var ride in driver.Rides)
                //{
                //    Console.WriteLine($"Ride ID : {ride.RideId}");
                //    Console.WriteLine($"From    : {ride.From}");
                //    Console.WriteLine($"To      : {ride.To}");
                //    Console.WriteLine($"Fare    : {ride.Fare:C2}");
                //    Console.WriteLine();
                //}

                Console.WriteLine("=================================\n");
            }

        }
    }
}
