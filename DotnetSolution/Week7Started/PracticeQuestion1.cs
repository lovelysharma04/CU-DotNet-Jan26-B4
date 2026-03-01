namespace Week7Started
{
    internal class PracticeQuestion1
    {

        public static string cleanseAndInvert(string input)
        {
            if (string.IsNullOrEmpty(input) || input.Length < 6) 
                return "";
            input = input.ToLower();
            string s = string.Empty;

            for (int i = 0; i < input.Length; i++)
            {
                if (!char.IsLetter(input[i])) 
                    return "";
                int c = input[i];
                if (c % 2 != 0)
                {
                    s += input[i];
                }

            }
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            string rev = new string(arr);
            string final = "";
            for (int i = 0; i < rev.Length; i++)
            {
                if (i % 2 == 0)
                {
                    final += char.ToUpper(rev[i]);
                }
                else
                {
                    final += rev[i];
                }
            }
            return final;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(cleanseAndInvert("Aeroplane"));         
        }
    }
}
