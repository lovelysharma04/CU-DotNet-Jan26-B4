namespace Week6Started
{
    internal class Demo8Recursion
    {
        public static void Main(string[] args)
        {
            fact(5);
        }
        static int fact(int n)
        {
            int space = 5;
            Console.WriteLine(new string(' ', space - n) + n);
            if (n == 0 || n == 1)
            {

                return 1;

            }
            int res = n * fact(n - 1);
            Console.WriteLine(new string(' ', space - n) + res);
            return res;

        }
    }
}
