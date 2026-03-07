namespace Week8Started
{
   class CreatorStats
    {
        public string CreatorName { get; set; }
        public double[] WeeklyLikes { get; set; }

        public static List<CreatorStats> EngagementBoard = new List<CreatorStats>();
        public void RegisterCreator(CreatorStats record)
        {
            EngagementBoard.Add(record); 
        }
        public Dictionary<string, int> GetTopPostCounts(List<CreatorStats> records, double likeThreshold)
        {
            Dictionary<string,int> d = new Dictionary<string, int>();
            foreach (var record in records)
            {
                foreach (var likes in WeeklyLikes)
                {
                    int count= 0;

                    if(likes >= likeThreshold)
                    {
                        count++;
                        d.Add(record.CreatorName,count);
                        
                    }
                    
                }
            }
            return d;
        }
        public double CalculateAverageLikes()
        {
            double sum = 0;
            int totalCount = 0;

            foreach (var creator in EngagementBoard)
            {
                foreach (var likes in creator.WeeklyLikes)
                {
                    sum += likes;
                    totalCount++;
                }
            }

            if (totalCount == 0)
                return 0;

            return sum / totalCount;
        }
    }
    internal class CreatorsEngagement
    {
        public static void Main(string[] args)
        {
            CreatorStats p =new CreatorStats();

            while (true)
            {
                Console.WriteLine("1. Register Creator");
                Console.WriteLine("2. Show Top Posts");
                Console.WriteLine("3. Calculate Average Likes");
                Console.WriteLine("4. Exit");
                Console.WriteLine("Enter your choice:");

                int choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 1)
                {
                    CreatorStats creator = new CreatorStats();

                    Console.WriteLine("Enter Creator Name:");
                    creator.CreatorName = Console.ReadLine();

                    creator.WeeklyLikes = new double[4];

                    Console.WriteLine("Enter weekly likes (Week 1 to 4):");

                    for (int i = 0; i < 4; i++)
                    {
                        creator.WeeklyLikes[i] = Convert.ToDouble(Console.ReadLine());
                    }

                    p.RegisterCreator(creator);

                    Console.WriteLine("Creator registered successfully");
                }

                else if (choice == 2)
                {
                    Console.WriteLine("Enter like threshold:");
                    double threshold = Convert.ToDouble(Console.ReadLine());

                    //var result = p.GetTopPostCounts(EngagementBoard, threshold);
                    var result = p.GetTopPostCounts(CreatorStats.EngagementBoard, threshold);

                    if (result.Count == 0)
                    {
                        Console.WriteLine("No top-performing posts this week");
                    }
                    else
                    {
                        foreach (var item in result)
                        {
                            Console.WriteLine($"{item.Key} - {item.Value}");
                        }
                    }
                }

                else if (choice == 3)
                {
                    double avg = p.CalculateAverageLikes();
                    Console.WriteLine($"Overall average weekly likes: {avg}");
                }

                else if (choice == 4)
                {
                    Console.WriteLine("Logging off - Keep Creating with StreamBuzz!");
                    break;
                }
            }
        }
    }
}
