

namespace Week5Started
{
    internal class Random2dArrayDemo1
    {
        static void Main(string[] args)
        {
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
            int t = 0;
            foreach (var item in arr)
            {
                Console.Write(item + "\t");
                t++;
                if (t % 5 == 0) { Console.WriteLine(); }
            }
            
        }
    }
}
