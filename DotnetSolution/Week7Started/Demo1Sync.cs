namespace Week7Started
{
    internal class Demo1Sync
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program Started...");
            DoSomethingSync();  //blocking calls
            Console.WriteLine("Could do other things while waiting...");
            Console.WriteLine("Program completed...");

        }
        static void DoSomethingSync()
        {
            Console.WriteLine("Time taking...");
            Thread.Sleep(2000);
            //Task.Delay(2000);
        }
    }
}
