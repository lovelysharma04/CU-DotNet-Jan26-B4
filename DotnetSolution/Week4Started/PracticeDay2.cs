
namespace Week4Started
{
    internal class PracticeDay2
    {
        static void Main(string[] args)
        {
            //string s = "abbaaacccddeeeaabbddcccc";
            //int Count = 1;
            //string res = "";
            //for (int i = 1; i < s.Length; i++)
            //{
            //    if (s[i] != s[i - 1])
            //    {
            //        res = res + s[i - 1];
            //        res = res + Count;
            //        Count = 0;
            //    }
            //    Count++;
            //}
            //res = res + s[s.Length - 1] + Count;
            //Console.WriteLine(res);

            Random rnd = new Random();

            //int n1 = rnd.Next(1, 25);   

            int[,] arr = new int[5, 5];
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {

                    int num;
                    bool exists;

                    do
                    {
                        num = rnd.Next(1, 26);
                        exists = false;

                        
                        for (int r = 0; r < arr.GetLength(0); r++)
                        {
                            for (int c = 0; c < arr.GetLength(1); c++)
                            {
                                if (arr[r, c] == num)
                                {
                                    exists = true;
                                    break;
                                }
                            }
                            if (exists) break;
                        }

                    } while (exists);

                    arr[i, j] = num;
                }
            }

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write($"{arr[i,j],5}");
                }
                Console.WriteLine();
            }

        }    
     }
}

