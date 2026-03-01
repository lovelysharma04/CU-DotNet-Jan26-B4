namespace CSharpLearning
{
    internal class Demo5Array
    {
        static void Main(string[] args)
        {
            //int[] marks = { 76, 87, 98, 99, 76 };
            //Console.WriteLine(marks.Length);
            //Console.WriteLine(marks.GetLength(0));

            //int[,] arr2d = new int[4, 3]; //2d rectangle array
            //Console.WriteLine(arr2d.Length);
            //Console.WriteLine(arr2d.GetLength(0));
            //Console.WriteLine(arr2d.GetLength(1));

            // 2D Array initalization
            int[,] arr2d =
            {
                {11,22,33,44,0 },
                {23,45,67,90,0 },
                {56,64,34,27,0 },
                {65,43,23,56,0 },
                {0,0,0,0,0 }
            };
           
            //rows
            for (int row = 0; row < arr2d.GetLength(0); row++)
            {
                int sum = 0;
                for (int col = 0; col < arr2d.GetLength(1); col++)
                {
                    sum += arr2d[row, col]; 
                }
                arr2d[row,arr2d.GetLength(1)-1] = sum;

            }
            //columns
             for (int col = 0; col < arr2d.GetLength(1); col++)
             {
                int sum = 0;
                for (int row = 0; row < arr2d.GetLength(0); row++)
                {
                    sum += arr2d[row,col];
                }
                arr2d[arr2d.GetLength(0)-1, col] = sum;
             }
            //printing
            for (int row = 0; row < arr2d.GetLength(0); row++)
            {
                
                for (int col = 0; col < arr2d.GetLength(1); col++)
                {
                    Console.Write($"{arr2d[row,col],5}"); 
                }
                Console.WriteLine();
            }

        }
    }
}
