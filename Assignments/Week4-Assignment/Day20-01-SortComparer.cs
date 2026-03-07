namespace Week4Started
{
    internal class Day20_01_SortComparer
    {
        class Flight: IComparable<Flight>
        {
            public string FlightNumber { get; set; }
            public decimal Price { get; set; }
            public TimeSpan Duration { get; set; }
            public DateTime DepartureTime { get; set; }

            public int CompareTo(Flight? other)
            {
                return this.Price.CompareTo(other?.Price);
            }
            public override string ToString()
            {
                return $"Flight Number: {FlightNumber}| Price: {Price}| Duration: {Duration}| Departure Time: {DepartureTime}";
            }
        }
        class DurationComparer : IComparer<Flight>
        {
            public int Compare(Flight? x, Flight? y)
            {
                return x.Duration.CompareTo(y.Duration); 
            }
        }
        class DepartureComparer : IComparer<Flight>
        {
            public int Compare(Flight? x, Flight? y)
            {
                return x.DepartureTime.CompareTo(y.DepartureTime);
            }
        }
        static void Main(string[] args)
        {
           List<Flight> list = new List<Flight>()
           {
               new Flight{FlightNumber = "360",Price = 5000,Duration = new TimeSpan(4, 0, 0),DepartureTime = new DateTime(2026, 2, 1, 10, 30, 0)},
               new Flight{FlightNumber = "145",Price = 3200,Duration = new TimeSpan(2, 0, 0),DepartureTime = new DateTime(2026, 2, 1, 8, 15, 0)},
               new Flight{FlightNumber = "789",Price = 4500,Duration = new TimeSpan(3, 30, 0),DepartureTime = new DateTime(2026, 2, 1, 14, 0, 0)},
               new Flight{FlightNumber = "902",Price = 6000,Duration = new TimeSpan(5, 0, 0), DepartureTime = new DateTime(2026, 4, 1, 18, 45, 0)},
               new Flight{FlightNumber = "418",Price = 2800,Duration = new TimeSpan(1, 30, 0),DepartureTime = new DateTime(2026, 3, 1, 6, 0, 0)}
           };
            list.Sort();
            Console.WriteLine("------------------------------------ Economy View --------------------------------------");
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            list.Sort(new DurationComparer());
            Console.WriteLine("--------------------------------- Business Runner View ---------------------------------");
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            list.Sort(new DepartureComparer());
            Console.WriteLine("----------------------------------- Early Bird View ------------------------------------");
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }
    }
}
