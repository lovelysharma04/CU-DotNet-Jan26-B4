namespace Week5Started
{
    internal class Day24_02_TheHighScoreLeaderboard
    {
        static void Main(string[] args)
        {
            SortedDictionary<double, string> leaderboard = new SortedDictionary<double, string>();
            leaderboard.Add(55.42,"SwiftRacer");
            leaderboard.Add(52.10,"SpeedDemon");
            leaderboard.Add(58.91,"SteadyEddie");
            leaderboard.Add(51.05,"TurboTom");

            foreach (var item in leaderboard)
            {
                Console.WriteLine($"Lap time(in seconds): {item.Key:F2}  Player: {item.Value}");
            }
            Console.WriteLine($"\nGold Medal Time: {leaderboard.First().Value}\n");

            foreach (var item in leaderboard)
            {
                if(item.Value == "SteadyEddie")
                {
                    double k = item.Key;
                    leaderboard.Remove(k);
                    break;
                }
                
            }
            leaderboard.Add(54.00, "SteadyEddie");
            foreach (var item in leaderboard)
            {
                Console.WriteLine($"Lap time(in seconds): {item.Key:F2}  Player: {item.Value}");
            }

        }
    }
}
