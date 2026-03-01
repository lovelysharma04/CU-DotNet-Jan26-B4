namespace Week3DotNet
{
    internal class MergeArray
    {
        static void Main(string[] args)
        {
            int[] a = { 70, 60, 80, 75, 90 };
            int[] b = { 75, 70, 78, 69, 92 };
            int[] c = MergeArrays(a, b);
            Console.WriteLine(string.Join(",",c)); 
        }

        static public int[] MergeArrays(int[] arrayA, int[] arrayB)
        {
            int[] MergeArray = new int[5];
            for (int i = 0; i < MergeArray.Length; i++)
            {
                if (i % 2 == 0)
                {
                    MergeArray[i] = Math.Max(arrayA[i], arrayB[i]);
                }
                else
                {
                    MergeArray[i] = (arrayA[i] + arrayB[i]) / 2;
                }

            }
            return MergeArray;
        }
    }
}
