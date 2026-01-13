using System.Globalization;
using System.Text;

namespace CSharpLearning
{
    internal class Demo2OutputFormatting
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Enter the number: ");
            //int n = int.Parse(Console.ReadLine());
            //for (int i = 1; i <=10; i++)
            //{ 
            //    Console.WriteLine($"{n} x {i,3} = {n*i,4}");

            //}

            string name = "Lovely Sharma";
            int value = 1234;
            Console.WriteLine($"|{name,-15}|{value,-10:F2}|");
            Console.WriteLine($"{10.0 / 3:0.00}");

            Console.OutputEncoding = Encoding.UTF8;
            int salary = 35000;
            Console.WriteLine($"{salary:C}");
            Console.WriteLine($"{salary:0.00}");

            Console.OutputEncoding = Encoding.UTF8;
            decimal salary1 = 50000;
            CultureInfo india = new CultureInfo("en-IN");
            Console.WriteLine(salary1.ToString("C", india));

        }
    }
}
