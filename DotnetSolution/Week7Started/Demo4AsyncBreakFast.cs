using System.Diagnostics;

namespace Week7Started
{
    internal class Demo4AsyncBreakFast
    {
        static async Task Main(string[] args)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();

            Console.WriteLine("Preparing Breakfast");
            var toast = MakeTost();
            var coffee = MakeCoffee();
            var egg = MakeEgg();
            Console.WriteLine("Utilizing waiting time");
            Console.WriteLine("Taking some short calls");
            Console.WriteLine("Making my breakfast table");

            string[] breakfast = await Task.WhenAll(toast, coffee, egg);
            
            watch.Stop();
            foreach (string item in breakfast)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(watch.ElapsedMilliseconds);
            Console.WriteLine("Completed All Tasks, Breakfast Ready!....");

        }
        static async Task<string> MakeTost()
        {
            await Task.Delay(3000);
            return "Toast ready";
        }
        static async Task<string> MakeCoffee()
        {
            await Task.Delay(2000);
            return "Coffee ready";
        }
        static async Task<string> MakeEgg()
        {
            await Task.Delay(4000);
            return "Egg ready";
        }
    }
}
