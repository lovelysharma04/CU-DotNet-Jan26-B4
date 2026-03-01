namespace Week7Started
{
    internal class DemoIndirectRecursion
    {
        public static void A(int n)
        {
            if (n <= 0) return;
            Console.WriteLine("A: "+n);
            B(n - 1);
        }
        public static void B(int n)
        {
            if (n <= 0) return;
            Console.WriteLine("B: " + n);
            A(n - 1);

        }
        static void Main(string[] args)
        {
            A(3);
        }
    }
}
