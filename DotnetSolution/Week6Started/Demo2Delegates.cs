namespace Week6Started
{
    delegate void MyDelegate();
    internal class Demo2Delegates
    {
        static void MyMethod1()
        {
            Console.WriteLine("MyMethod1");
        }
        static void MyMethod2()
        {
            Console.WriteLine("MyMethod2");
        }
        static void Main(string[] args)
        {
            MyDelegate del1 = MyMethod1;
            del1 += MyMethod2;
            del1();
            Console.WriteLine("----------------------");
            del1 -= MyMethod1;
            del1();

        }
    }
}
