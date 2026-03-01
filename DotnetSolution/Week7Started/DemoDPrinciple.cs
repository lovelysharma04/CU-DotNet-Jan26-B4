namespace ClassPractice
{
    interface IDevice
    {
        void Print();
    }
    class Printer : IDevice
    {
        public void Print()
        {
            Console.WriteLine("Printer Printing");
        }
    }
    class InkjetPrinter : IDevice
    {
        public void Print()
        {
            Console.WriteLine("Injket Printer Printing");
        }
    }
    class Computer
    {
        private IDevice device;

        //private Printer p = new Printer();
        public Computer(IDevice d)
        {
            device = d;
        }

        public void StartPrinting()
        {
            device.Print();
            //p.Print();
        }
    }
    internal class DemoDPrinciple
    {
        static void Main(string[] args)
        {
            IDevice device = new InkjetPrinter();
            IDevice device1 = new Printer();
            Computer c = new Computer(device);
            Computer c1 = new Computer(device1);
            //Computer c = new Computer();
            c.StartPrinting();
            c1.StartPrinting();
        }
    }
}