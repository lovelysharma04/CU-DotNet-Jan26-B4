namespace Week7Started
{
    internal class Demo3AsyncCallsReturn
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Program Started...");
            var result = DoSomethingAsync(); //non blocking calls
            Console.WriteLine("Could do other things while waiting...");
            for (int i = 1; i <= 18000; i++)
            {
                if (result.IsCompleted)
                {
                    Console.WriteLine("--------- Task Done ---------");
                    break;   
                }
                Console.Write(i + " ");
            }
            string value = await result;
            Console.WriteLine(value);
            Console.WriteLine("Program completed...");

        }
        static async Task<string> DoSomethingAsync()
        {
            Console.WriteLine("Time taking...");
            await Task.Delay(2000);
            Console.WriteLine("Task completed...");
            return "--- TASK RESULT ---";

        }
    }
}
