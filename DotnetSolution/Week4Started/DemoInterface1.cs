namespace Week4Started
{
    interface IDemo
    {
        void hello();
    }
    internal class DemoInterface1
    {

        static IEnumerable<int> GetFactorial(int num)
        {
            int fact = 1;
            for (int  i = 2; i <=num; i++)
            {
                fact*=i;
                yield return fact;
            }
        }
        static void Main(string[] args)
        {
            //Console.WriteLine(GetFactorial(5));
            foreach (var item in GetFactorial(5))
            {
                Console.WriteLine(item);
            }
        }
    }
}
