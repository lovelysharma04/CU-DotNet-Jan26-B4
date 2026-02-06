namespace Week5Started
{
    internal class Day27_01_DailyLogger
    {
        static void Main(string[] args)
        {
            string myfile = @"../../../journal.txt";
            using StreamWriter sw = new StreamWriter(myfile, true);
            Console.WriteLine("Enter User Name: ");
            string name = Console.ReadLine();
            sw.WriteLine(name);

        }
    }
}
