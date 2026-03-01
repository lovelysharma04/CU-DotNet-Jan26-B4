namespace Week7Started
{
    internal class Demo2Async
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Program Started...");
            var result= DoSomethingAsync(); //non blocking calls
            Console.WriteLine("Could do other things while waiting...");
            for (int i = 0; i < 1000; i++)
            {
                Console.Write(i+ " ");
            }
            await result;
            
            Console.WriteLine("Program completed...");

        }
        static async Task DoSomethingAsync()
        {
            Console.WriteLine("Time taking...");
            await Task.Delay(2000);
            Console.WriteLine("Task completed...");
           
        }
    }
}
