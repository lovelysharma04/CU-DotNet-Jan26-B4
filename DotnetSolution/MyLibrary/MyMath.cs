namespace MyLibrary
{
    public class MyMath
    {
        public int GetSum(params int[] nums)
        {
            int sum = 0;
            foreach(int i in nums) { sum+= i; }
            return sum;
        }
        public int GetMultiply(int n1, int n2)
        {
            int m = n1*n2;
            
            return m;
        }
    }
}
