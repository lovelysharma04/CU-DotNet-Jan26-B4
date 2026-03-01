namespace Week6Started
{
    internal class ClimbingtheLeaderboard
    {
        public static List<int> LeaderBoard(List<int> ranked, List<int> players)
        {
            List<int> result = new List<int>();

            // remove duplicates
            List<int> distinctRank = ranked.Distinct().ToList();
            for(int i = 0; i < players.Count; i++)
            {
                if (!distinctRank.Contains(players[i]))
                {
                    distinctRank.Add(players[i]);
                    distinctRank.Sort();
                    distinctRank.Reverse();
                    
                }
                int j = distinctRank.IndexOf(players[i]);
                result.Add(j + 1);

            }
            return result;

        }
        static void Main(string[] args)
        {
            List<int> ranked = new List<int> { 100, 100, 50, 40, 40, 20, 10};
            List<int> player = new List<int> { 5, 25, 50, 120 };
            List<int> result = new List<int>();
            result = LeaderBoard(ranked, player);
            Console.WriteLine(string.Join(",",result));

        }
    }
}
