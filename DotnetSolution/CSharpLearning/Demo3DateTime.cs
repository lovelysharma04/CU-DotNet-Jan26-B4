using MyClassLibrary;

namespace CSharpLearning
{
    internal class Demo3DateTime
    {
        static void Main(string[] args)
        {
            DateTime today = DateTime.Today;
            Console.WriteLine(today);
            Console.WriteLine($"{today:dd/MM/yyyy}");
            Console.WriteLine($"{today:dd/MMM/yyyy}");//mm : minutes  MM: months
            Console.WriteLine($"{today:dd/MMMM/yyyy}");

            DateTime now = DateTime.Now;
            Console.WriteLine(now);

            Console.WriteLine(MyMath.GetCube(4567));



        }
    }
}
