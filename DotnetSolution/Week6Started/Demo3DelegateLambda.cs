namespace Week6Started
{
    public delegate void MyDelegate2();
    internal class Demo3DelegateLambda
    {
        static void Main(string[] args)
        {
            MyDelegate2 del1 = delegate ()
            {
                Console.WriteLine("Anonymous method");
            };

            MyDelegate2 del2 = () => Console.WriteLine("Lambda method");

            //=================== Action ======================================

            Action act1= () => Console.WriteLine("Action working...");  //anonymous delegate
            Action<int> act2 = (x) => Console.WriteLine("Action working.." + x);
            Action<int,int> sum = (x,y) => Console.WriteLine("Sum is " + x+y);
            Action<int, string> act4 = (num, name) =>
            {
                Console.WriteLine("Action working.." + num);
                Console.WriteLine("name: " + name);
            };

            //=================== Func =========================================

            Func<int, int> GetDouble = (x) => x * 2;
            Func<int, int,int> GetSum = (x,y) => x+y;

            act1();
            act2(10);
            sum(8, 9);
            act4(1, "Nobita");
            Console.WriteLine(GetDouble(19876));
            Console.WriteLine(GetSum(56,89));

            del1();

        }
    }
}
