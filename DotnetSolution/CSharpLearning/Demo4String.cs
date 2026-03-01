
using System;

namespace CSharpLearning
{
    internal class Demo4String
    {
        static void Main(string[] args)
        {
            //string name = "Abcd";
            //Console.WriteLine(name.GetHashCode());
            //name= name + "e";
            //Console.WriteLine(name.GetHashCode());
            ////index is used as a indexer--------- Topic in OOPs
            //Console.WriteLine(name[4]);
            ////========================================================sum of numbers in a string===============================================================
            //Console.WriteLine("Enter a string: ");
            //string s = Console.ReadLine();
            //s = s.Trim();
            //int sum = 0;
            //for (int i = 0; i < s.Length; i++)
            //{
            //    if (char.IsDigit(s[i]))
            //    {
            //        sum = sum + (int)s[i]-'0';
            //    }
            //}
            //Console.WriteLine(sum);

            ////=========================================substring in parantheses================================================================
            //string st = "ghsdgfjhgf(Lovely)hghgjs";
            //int i = st.IndexOf("(");
            //int j = st.IndexOf(")");
            //string sub = st.Substring(i + 1, j - i - 1);

            //Console.WriteLine(sub);

            //===============================================================return indices of repeated string in string=======================================================
            string st = "ghsdgfjhgf(Lovelygh)hghgjs";
            string search = "gh";

            for (int i = 0; i <= st.Length - 1; i++)
            {
                int index = st.IndexOf(search, i);
                if (index == -1)
                    break;
                //i = index - 1;
                Console.WriteLine(index);
                i = index;
            }

            string s1 = "ab";
            char[] s2 = {'a','b' };
            string s3 = new string(s2);
            Console.WriteLine(s1.GetHashCode());
            Console.WriteLine(s3.GetHashCode());
            Console.WriteLine(Object.ReferenceEquals(s1,s3));

            string[] values = { "aa", "bb", "cc", "dd" };
            Console.WriteLine(string.Join(',', values));

            string s4 = @"c:\tytuyt\jhjhj\jhjk.txt";
        }
    }
}
