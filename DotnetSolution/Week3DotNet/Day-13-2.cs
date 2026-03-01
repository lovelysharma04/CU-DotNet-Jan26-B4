namespace Week3DotNet
{
    internal class Day_13_2
    {
        static void Main(string[] args)
        {
            
            Display();
            Display(ch:'$');
            Display(ch: '$', num: 55);
            Display(60,'+');
            MultipleDefParameters(6,7);
        }
        static void Display(int num=40,char ch='-')
        {
            for (int i = 0; i < num; i++)
            {
                Console.Write(ch);
            }
            Console.WriteLine();
        }

        static void InParaMethod(in int y)
        {
            //y++; //read only
        }

        static void MultipleDefParameters(int a = 1,int b=2, int c=3, int d=4, int e=5)
        {
            Console.WriteLine($"a: {a} b: {b} c: {c} d: {d} e: {e}");

        }
    }
}
