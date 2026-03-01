namespace Week6Started
{
    internal class Demo4LINQ
    {
        static void Main(string[] args)
        {
            List<int> values = new List<int> {
                12,34,67,34,89,23,30,91,83,33,45,22,8,12
            };
            Console.WriteLine(values.Count());
            var aboveFifty = values.Where(x => x > 50)
                                   .OrderByDescending(x=>x);

            List<int> aboveFiftyList = values.Where(x => x > 50).ToList();

            Console.WriteLine(string.Join(",",aboveFifty));
        }
    }
}
