
namespace WeeklyAssisment
{
    internal class Week2Assisment
    {
        static void Main(string[] args)
        {
            string[] policyHolderNames = new string[5];
            decimal[] annualPremiums = new decimal[5];

            //1. Input
            for (int i = 0; i < policyHolderNames.Length; i++)
            {
                Console.Write($"Enter the Name of Policy Holder {i+1}: ");
                policyHolderNames[i]= Console.ReadLine();
                if (string.IsNullOrEmpty(policyHolderNames[i]))
                {
                    i--;
                    Console.WriteLine("Re-Enter the name (Name can not be empty!)... ");
                }
            }

            Console.WriteLine(string.Join(", ", policyHolderNames));

            for (int i = 0;i < annualPremiums.Length; i++)
            {
                Console.Write($"Enter the Annual premium amount {i + 1}: ");
                annualPremiums[i] = decimal.Parse(Console.ReadLine());
                if (annualPremiums[i] < 0)
                {
                    i--;
                    Console.WriteLine("Re-Enter the Amount!");
                }

            }
            Console.WriteLine(string.Join(", ", annualPremiums));

            //•	Total premium amount
            decimal sum = 0m;
            for (int i = 0; i < annualPremiums.Length ; i++)
            { 
                sum += annualPremiums[i];
            }
            
            //•	Highest premium
            decimal high = annualPremiums.Max();
       
            //•	Lowest premium
            decimal low = annualPremiums.Min();

            Console.WriteLine("=====================================Insurance Premium Summary=====================================");
            Console.WriteLine("\n---------------------------------------------------------------------------------------------------");
            Console.WriteLine($"{"Name",-15}{"Premium",-15}{"Category",-15}");
            Console.WriteLine("---------------------------------------------------------------------------------------------------");

            for (int i = 0; i < annualPremiums.Length; i++)
            {
                if (annualPremiums[i] < 10000)
                {
                    Console.WriteLine($"{policyHolderNames[i].ToUpper(),-15}{annualPremiums[i],-15}{"LOW",-15}");
                }
                else if((annualPremiums[i] >= 10000 && annualPremiums[i] <= 25000))
                {
                    Console.WriteLine($"{policyHolderNames[i].ToUpper(),-15}{annualPremiums[i],-15}{"MEDIUM",-15}");
                }
                else if(annualPremiums[i] > 25000)
                {
                    Console.WriteLine($"{policyHolderNames[i].ToUpper(),-15}{annualPremiums[i],-15}{"HIGH",-15}");
                }
            }

            Console.WriteLine("-----------------------------------------------------------------------------------------------------");
            Console.WriteLine($"Total premium amount: {sum:C2}");
            Console.WriteLine($"Average premium: {sum / 5m:C2}");
            Console.WriteLine($"Highest premium: {high:C2}");
            Console.WriteLine($"Lowest premium: {low:C2}");

        }
    }
}
