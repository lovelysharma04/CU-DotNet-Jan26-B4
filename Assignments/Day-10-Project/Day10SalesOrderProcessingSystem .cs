namespace CSharpLearning
{
    internal class Day10SalesOrderProcessingSystem
    {
        static void Main(string[] args)
        {
            const int days = 7;

            decimal[] sales = new decimal[days];
            string[] categories = new string[days];

            ReadWeeklySales(sales);

            decimal total = CalculateTotal(sales);
            decimal avg = CalculateAverage(total, days);

            int highDay, lowDay;
            decimal high = FindHighestSale(sales, out highDay);
            decimal low = FindLowestSale(sales, out lowDay);

            bool isFestivalWeek = true;

            decimal discount = CalculateDiscount(total, isFestivalWeek);
            decimal taxableAmount = total - discount;
            decimal tax = CalculateTax(taxableAmount);
            decimal finalPayable = CalculateFinalAmount(total, discount, tax);

            GenerateSalesCategory(sales, categories);

            Console.WriteLine("\nWeekly Sales Summary");
            Console.WriteLine("--------------------");
            Console.WriteLine($"Total Sales        : {total:F2}");
            Console.WriteLine($"Average Daily Sale : {avg:F2}\n");

            Console.WriteLine($"Highest Sale       : {high:F2} (Day {highDay})");
            Console.WriteLine($"Lowest Sale        : {low:F2}  (Day {lowDay})\n");

            Console.WriteLine($"Discount Applied   : {discount:F2}");
            Console.WriteLine($"Tax Amount         : {tax:F2}");
            Console.WriteLine($"Final Payable      : {finalPayable:F2}\n");

            Console.WriteLine("Day-wise Category:");
            for (int i = 0; i < days; i++)
            {
                Console.WriteLine($"Day {i + 1} : {categories[i]}");
            }
        }

        static void ReadWeeklySales(decimal[] sales)
        {
            for (int i = 0; i < sales.Length; i++)
            {
                while (true)
                {
                    Console.Write($"Enter sales for Day {i + 1}: ");
                    decimal val = decimal.Parse(Console.ReadLine());

                    if (val >= 0)
                    {
                        sales[i] = val;
                        break;
                    }
                }
            }
        }

        static decimal CalculateTotal(decimal[] sales)
        {
            decimal sum = 0;
            for (int i = 0; i < sales.Length; i++)
                sum += sales[i];
            return sum;
        }

        static decimal CalculateAverage(decimal total, int days)
        {
            return total / days;
        }

        static decimal FindHighestSale(decimal[] sales, out int day)
        {
            decimal max = sales[0];
            day = 1;

            for (int i = 1; i < sales.Length; i++)
            {
                if (sales[i] > max)
                {
                    max = sales[i];
                    day = i + 1;
                }
            }
            return max;
        }

        static decimal FindLowestSale(decimal[] sales, out int day)
        {
            decimal min = sales[0];
            day = 1;

            for (int i = 1; i < sales.Length; i++)
            {
                if (sales[i] < min)
                {
                    min = sales[i];
                    day = i + 1;
                }
            }
            return min;
        }

        static decimal CalculateDiscount(decimal total)
        {
            return total >= 50000 ? total * 0.10m : total * 0.05m;
        }

        static decimal CalculateDiscount(decimal total, bool isFestivalWeek)
        {
            decimal discount = CalculateDiscount(total);

            if (isFestivalWeek)
                discount += total * 0.05m;

            return discount;
        }

        static decimal CalculateTax(decimal amount)
        {
            return amount * 0.18m;
        }

        static decimal CalculateFinalAmount(decimal total, decimal discount, decimal tax)
        {
            return total - discount + tax;
        }

        static void GenerateSalesCategory(decimal[] sales, string[] categories)
        {
            for (int i = 0; i < sales.Length; i++)
            {
                if (sales[i] < 5000)
                    categories[i] = "Low";
                else if (sales[i] <= 15000)
                    categories[i] = "Medium";
                else
                    categories[i] = "High";
            }
        }  
    }
}
