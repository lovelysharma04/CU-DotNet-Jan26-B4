namespace CSharpLearning
{
    internal class Day9WeeklySalesAnalysisSystem
    {
        static void Main(string[] args)
        {
            decimal[] arr = new decimal[7];
            Console.WriteLine("Enter Sales value of each day: ");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"Day {i+1} sale: ");
                arr[i]= decimal.Parse(Console.ReadLine());
                if (!(arr[i] >= 0))
                {
                    i--;
                    Console.WriteLine("Re-enter for the same day!");
                }
            }
            
            Console.WriteLine("\nWeekly Sales Report\r\n--------------------------------------------------------------------------------------------------\r\n");
            //1.Total Weekly Sales
            decimal sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            Console.WriteLine($"Total Weekly Sales: {sum:F2}");

            //2.Average Daily Sales
            Console.WriteLine($"Average Daily Sales: {sum/7m:F2}");

            //3.Highest Sales Day
            decimal high = arr.Max();
            Console.WriteLine($"Highest Sales Day: {high:F2}");

            //4.Lowest Sales Day
            decimal low = arr.Min();
            Console.WriteLine($"Lowest Sales Day: {low:F2}");

            //5.Days Above Average
            decimal avg = sum / 7m;
            int above = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if( arr[i] > avg)
                {
                    Console.WriteLine($"\nDay {i} has sales above average!");
                    above++;
                } 
            }
            Console.WriteLine($"\nDays above average: {above}");

            Console.WriteLine("Day-wise sales category summary");
            string[] sales = new string[7];
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i]< 5000)
                {
                    Console.WriteLine($"Day {i+1}: LOW");

                }
                else if ((arr[i]>= 5000 && arr[i] <= 15000))
                {
                    Console.WriteLine($"Day {i+1}: MEDIUM");
                }
                else
                {
                    Console.WriteLine($"Day {i + 1}: HIGH");
                }


            }

        }
    }
}
