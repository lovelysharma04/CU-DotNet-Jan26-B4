using System.Diagnostics;

namespace Week6Started
{
    internal class Demo1Trace
    {
        static int GetSum(params int[] arr)
        {
            if (arr.Length == 0)
            {
                Trace.TraceInformation("No value passed");
                Trace.TraceWarning("No value passed");
                Trace.TraceError("No value passed");
            }
            else
                Trace.TraceInformation($"{arr.Length} numbers passed ");
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            return sum;
        }
        static void Show()
        {
            Trace.WriteLine("Show Method Called");
            Console.WriteLine("Show Method Called");
        }
        static void Display()
        {
            Trace.WriteLine("Display Method Called");
            Console.WriteLine("Display Method Called");
        }
        static void Main(string[] args)
        {
            string tracefile = @"..\..\..\trace.log";
            var listner = new TextWriterTraceListener(tracefile);
            Trace.Listeners.Add(listner);
            Trace.AutoFlush = true;
            Trace.WriteLine(DateTime.Now);
            Trace.WriteLine("Main Started...");
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int result = GetSum(arr);
            int result2 = GetSum(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
            Console.WriteLine(result);
            Console.WriteLine(result2);
            int result3 = GetSum();
            Console.WriteLine(result3);
            Trace.Listeners.Remove(listner);
            Show();
            Display();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }
            Trace.WriteLine("Main Completed...");

        }
    }
}
