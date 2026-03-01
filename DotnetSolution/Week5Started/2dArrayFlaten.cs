namespace Week5Started
{
    internal class _2dArrayFlaten
    {
        static void Main(string[] args)
        {
            int[,] arr2d = new int[5, 5];
            Random rnd = new Random();
            for (int i = 0; i < arr2d.GetLength(0); i++)
            {
                for(int j = 0; j < arr2d.GetLength(1); j++)
                {
                    arr2d[i, j] = rnd.Next(1, 26);
                }
            }
            //Console.WriteLine(arr2d.Length);

            //List<int> list = new List<int>();
            int[] arr1d = new int[arr2d.Length];
            for (int i = 0; i < arr2d.Length; i++)
            {
                for (int j = 0; j < arr2d.Length; j++)
                {
                    arr1d[i] = arr2d[i, j];
                }
            }
        }
    }
}
