namespace Week4Started
{
    internal class Demo2CollectionInterfaces
    {
        class Laptop : IComparable<Laptop>
        {
            public int LaptopID { get; set; }
            public string Company { get; set; }
            public string ModelName { get; set; }
            public int Price { get; set; }

            public int CompareTo(Laptop? other)
            {
                return this.LaptopID.CompareTo(other?.LaptopID);
            }

            //public int CompareTo(object? obj)
            //{
            //    Laptop other = obj as Laptop;
            //    return this.LaptopID.CompareTo(other.LaptopID);
            //   // throw new NotImplementedException();
            //}
            public override string ToString()
            {
                return $"ID: {LaptopID}| Name: {ModelName}| Company: {Company}| Price: {Price}";
            }
        }
        class LaptopPriceSorter : IComparer<Laptop>
        {
            public int Compare(Laptop? x, Laptop? y)
            {
                return x.Price.CompareTo(y.Price);
            }
        }
        class LaptopCompanySorter : IComparer<Laptop>
        {
            public int Compare(Laptop? x, Laptop? y)
            {
                return x.Company.CompareTo(y.Company);
            }
        }
        internal class ImoreAndAbstract
        {
            static void Main(string[] args)
            {
                List<Laptop> laptops = new List<Laptop>()
                {
                new(){LaptopID=302, Company="HP", ModelName ="15s", Price=50000},
                new(){LaptopID=303, Company="Lenovo", ModelName ="Ideapad3", Price=55000},
                new(){LaptopID=301, Company="Asus", ModelName ="TUF", Price=40000}
                };
                LaptopPriceSorter p = new LaptopPriceSorter();
                laptops.Sort(p);                              
                //laptops.Sort(new LaptopCompanySorter());  //comparer - with obj  //comparable- without obj
                //Array.Sort(laptops);
                //Laptop l = new Laptop()
                //{
                //    LaptopID = 0,
                //     Company = "Dell",
                //     ModelName = "Alienware",
                //     Price= 65000
                //};
                //laptops.Add(l);
                foreach (var laptop in laptops)
                {
                    Console.WriteLine(laptop);
                }
                Console.WriteLine("Done");
            }
        }
    }
}
