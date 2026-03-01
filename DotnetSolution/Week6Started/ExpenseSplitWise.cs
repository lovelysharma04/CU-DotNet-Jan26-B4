using System.Diagnostics.CodeAnalysis;

namespace Week6Started
{
    internal class ExpenseSplitWise
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter The Number of Persons: ");
            int n = int.Parse(Console.ReadLine());

            double[] expense = new double[n];
            for (int i = 0; i < expense.Length; i++)
            {
                Console.WriteLine($"Enter Person {i+1} Expense: ");
                expense[i]=double.Parse(Console.ReadLine());
            }
            
            double[] diff = new double[n];

            double sum = 0;

            for (int i = 0; i < expense.Length; i++)
            {
                sum += expense[i];
            }

            double equal = sum / expense.Length;

            for (int i = 0; i < expense.Length; i++)
            {
                diff[i] = equal - expense[i];
            }

            Console.WriteLine(string.Join(",", diff));
           
            for (int i = 0; i < n; i++)
            {
                if (diff[i] < 0)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (diff[j] > 0)
                        {
                            double amount = (-diff[i] < diff[j]) ? -diff[i] : diff[j];

                            Console.WriteLine($"Person {i + 1} pays {amount} to Person {j + 1}");

                            diff[i] += amount;
                            diff[j] -= amount;

                            if (diff[i] == 0)
                                break;

                        }
                    }
                }
            }
        }
    }
}
