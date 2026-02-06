using System.Xml.Linq;

namespace Week5Started
{
    public class Loan
    {
        public string ClientName { get; set; }
        public double Principal { get; set; }
        public double InterestRate { get; set; }
        public string Risk {  get; set; }
       
    }
    internal class Day27_02_TheLoanPortfolioManager
    {
        static void Main(string[] args)
        {
            List<Loan> l = new List<Loan>();
            string path = @"..\..\..\data.csv";
            using StreamWriter sw = new StreamWriter(path,true);
            FileInfo f = new FileInfo(path);
            if (f.Length == 0)
            {
                sw.WriteLine($"{"CLIENT",-15} |  {"PRINCIPLE",-15} |  {"INTEREST",-15} |  {"RISK LEVEL",-15}");
                sw.WriteLine("--------------------------------------------------------------------");
            }
            try
            {

                do
                {
                    Console.WriteLine("Enter ClientName, Principle, InterestRate (seperated by ,) (otherwise stop): ");
                    string[] arr = Console.ReadLine().Split(",");
                    string name = arr[0];
                    if (arr[0] == "stop")
                    {
                        break;
                    }
                    double p = double.Parse(arr[1]);
                    double r = double.Parse(arr[2]);
                    string risk;
                    double si = p * r / 100;
                    
                    if (r > 10)
                    {
                        risk = "HIGH";
                    }
                    else if (r >=5 && r <= 10)
                    {
                        risk = "MEDIUM";
                    }
                    else
                    {
                        risk = "LOW";
                    }

                    l.Add(new Loan()
                    {
                            ClientName = name,
                            Principal = p,
                            InterestRate = si,
                            Risk = risk
                    });


                } while (true);

                foreach (Loan item in l)
                {
                    sw.WriteLine($"{item.ClientName,-15} |  {item.Principal,-15:C2} |  {item.InterestRate,-15:C2} |  {item.Risk.ToUpper(),-15}");

                }
            }
            catch (Exception ex) 
            { 
                Console.WriteLine("Existing...");
            }
        }
    }
}
