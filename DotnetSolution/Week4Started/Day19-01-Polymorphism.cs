namespace Week4Started
{
    abstract class Vehicle
    {
        public string ModelName { get; set; }
        public Vehicle(string m)
        {
            ModelName = m;
        }
        public abstract void Move();
        public virtual string GetFuelStatus()
        {
            return "Fuel level is stable.";
        }
    }
    class ElectricCar : Vehicle
    {
        public ElectricCar(string m): base(m) 
        {
            ModelName = m;
        }
        public override void Move()
        {
            Console.WriteLine($"{ModelName} is gliding silently on battery power.");
        }
        public override string GetFuelStatus()
        {
            return $"{ModelName} battery is at 80%.";
        }
    }
    class  HeavyTruck: Vehicle
    {
        public HeavyTruck(string m) : base(m)
        {
            ModelName = m;
        }
        public override void Move()
        {
            Console.WriteLine($"{ModelName} is hauling cargo with high-torque diesel power.");
        }
        
    }
    class CargoPlane: Vehicle
    {
        public CargoPlane(string m) : base(m)
        {
            ModelName = m;
        }
        public override void Move()
        {
            Console.WriteLine($"{ModelName} is ascending to 30,000 feet.");
        }
        public override string GetFuelStatus()
        {
            return base.GetFuelStatus() + " Checking jet fuel reserves... ";
        }
    }

    internal class Day19_01_Polymorphism
    {
        static void Main(string[] args)
        {
            Vehicle[] v = new Vehicle[] {
                new ElectricCar("Mahindra BE 6"),
                new HeavyTruck("Mahindra Blazo X 40"),
                new CargoPlane("Airbus A330-200F")
            };
            foreach (var item in v)
            {
                item.Move();
                Console.WriteLine(item.GetFuelStatus());
                Console.WriteLine();
            }
        }
    }
}
