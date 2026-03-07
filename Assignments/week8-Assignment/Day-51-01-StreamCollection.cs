public class CreatorStats
{
    public string CreatorName { get; set; }
    public double[] WeeklyLikes { get; set; }
}
internal class StreamCollection
{
    public static List<CreatorStats> EngagementBoard = new List<CreatorStats>();

    public void RegisterCreator(CreatorStats record)
    {
        EngagementBoard.Add(record);
    }

    public Dictionary<string, int> GetTopPostCounts(List<CreatorStats> records, double likeThreshold)
    {
        Dictionary<string, int> result = new Dictionary<string, int>();

        foreach (CreatorStats creator in records)
        {
            int count = 0;

            foreach (double likes in creator.WeeklyLikes)
            {
                if (likes >= likeThreshold)
                {
                    count++;
                }
            }

            if (count > 0)
            {
                result[creator.CreatorName] = count;
            }
        }

        return result;
    }

    public double CalculateAverageLikes()
    {
        double sum = 0;
        int totalWeeks = 0;

        foreach (CreatorStats creator in EngagementBoard)
        {
            foreach (double likes in creator.WeeklyLikes)
            {
                sum += likes;
                totalWeeks++;
            }
        }

        if (totalWeeks == 0)
            return 0;

        return sum / totalWeeks;
    }

    public static void Main(string[] args)
    {
        StreamCollection p = new StreamCollection();
        int choice;

        do
        {
            Console.WriteLine("1. Register Creator");
            Console.WriteLine("2. Show Top Posts");
            Console.WriteLine("3. Calculate Average Likes");
            Console.WriteLine("4. Exit");
            Console.WriteLine("Enter your choice:");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    CreatorStats cs = new CreatorStats();
                    cs.WeeklyLikes = new double[4];

                    Console.WriteLine("Enter Creator Name:");
                    cs.CreatorName = Console.ReadLine();

                    Console.WriteLine("Enter weekly likes (Week 1 to 4):");
                    for (int i = 0; i < 4; i++)
                    {
                        cs.WeeklyLikes[i] = double.Parse(Console.ReadLine());
                    }

                    p.RegisterCreator(cs);
                    Console.WriteLine("Creator registered successfully");
                    Console.WriteLine();
                    break;

                case 2:
                    Console.WriteLine("Enter like threshold:");
                    double threshold = double.Parse(Console.ReadLine());

                    Dictionary<string, int> result =
                        p.GetTopPostCounts(EngagementBoard, threshold);

                    if (result.Count == 0)
                    {
                        Console.WriteLine("No top-performing posts this week");
                    }
                    else
                    {
                        foreach (var item in result)
                        {
                            Console.WriteLine(item.Key + " - " + item.Value);
                        }
                    }
                    Console.WriteLine();
                    break;

                case 3:
                    double avg = p.CalculateAverageLikes();
                    Console.WriteLine("Overall average weekly likes: " + avg);
                    Console.WriteLine();
                    break;

                case 4:
                    Console.WriteLine("Logging off - Keep Creating with StreamBuzz!");
                    break;
            }

        } while (choice != 4);
    }
}

