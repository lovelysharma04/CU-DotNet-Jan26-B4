namespace Week3DotNet
{
    internal class PracticeDay1
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(IsPalindrome("nitin"));
            int n;
            Console.Write("Enter a num: ");
            n = int.Parse(Console.ReadLine());
            CreatFlag(n);
            //second largest value ---------------------------------------------------------------
            int[] a = {22,33,44,55,66,77,88,99};
            Array.Sort(a);
            Console.WriteLine($"Second Max value: {a[a.Length-2]}");

        }
        public static void CreatFlag(int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 1; j <= i+1; j++)
                {
                    Console.Write($"{j}");
                      
                }
                Console.WriteLine();
            }
            
            for (int i = n; i>0 ; i--)
            {
                for (int j = 1; j < i; j++)
                {
                    Console.Write($"{j}");

                }
                Console.WriteLine();
            }

        }

        //public static bool IsPalindrome(string s)
        //{
        //    s = s.ToLower();
        //    string reversed = string.Empty;

        //    for (int i = s.Length - 1; i >= 0; i--)
        //    {
        //        reversed += s[i];
        //    }

        //    if (s.Equals(reversed))
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
    }
}
