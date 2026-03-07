namespace Week5Started
{
    class Player
    {
        public string Name { get; set; }
        public int RunsScored { get; set; }
        public int BallsFaced  { get; set; }
        public bool IsOut  { get; set; }
        public double StrikeRate { get; set; }
        public double Average { get; set; }
    }
    internal class Day25_02_CricketPlayerPerformanceTracker
    {
        static void Main(string[] args)
        {
            string file = @"../../../Players.csv";
            List<Player> list = new List<Player>();
            try
            {
                using StreamReader sr = new StreamReader(file);
                sr.ReadLine();  //skip header
                while (!sr.EndOfStream) 
                {
                    string line = sr.ReadLine();
                    string[] arr = line.Split(",");

                    string name = arr[0].Trim();
                    int runs= int.Parse(arr[1]);
                    int balls= int.Parse(arr[2]);
                    bool isOut = bool.Parse(arr[3]);

                    double st = ((double)runs / balls) * 100;
                    double avg= isOut ? runs / 1.0 : runs;

                    list.Add(new Player { 
                        Name = name,
                        RunsScored = runs,
                        StrikeRate = st,
                        Average= avg
                    });
     
                }
              
                list = list
                       .OrderByDescending(p => p.StrikeRate)
                       .ToList();

                Console.WriteLine($"{"Name",-15}{"Runs",-15}{"Strike Rate",-15}{"Average",-15}");
                Console.WriteLine(new string('-', 55));
                foreach (Player p in list)
                {
                    Console.WriteLine($"{p.Name,-15}{p.RunsScored,-15}{p.StrikeRate,-15:F2}{p.Average,-15:F2}");
                }

            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message + " No Such CSV File Exist..");
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            

        }
    }
}
