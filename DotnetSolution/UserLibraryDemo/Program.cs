using MyClassLibrary;

namespace UserLibraryDemo
{
    internal class Program: Object
    {
        static void Main(string[] args)
        {
            //MyMath.GetDouble(56);
            Console.Write("Enter a number: ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine($"Double: {MyMath.GetDouble(n)}");
            Console.WriteLine($"cube: {MyMath.GetCube(n)}");
        }
    }
}
