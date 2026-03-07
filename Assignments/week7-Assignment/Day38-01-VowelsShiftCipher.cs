namespace Week7Started
{
    internal class PracticeQuestion2
    {
        public static string VowelShift(string input)
        {
            char[] arr = input.ToCharArray();
            string vowels = "aeiou";

            for (int i = 0; i < arr.Length; i++)
            {
                
                if (arr[i] == 'a') arr[i] = 'e';
                else if (arr[i] == 'e') arr[i] = 'i';
                else if (arr[i] == 'i') arr[i] = 'o';
                else if (arr[i] == 'o') arr[i] = 'u';
                else if (arr[i] == 'u') arr[i] = 'a';
                else if (arr[i] == 'z') arr[i] = 'b';

                else
                {
                    
                    arr[i] = (char)(arr[i]  + 1) ;

                    
                    if (vowels.Contains(arr[i]))
                    {
                        arr[i] = (char)(arr[i] + 1);
                    }
                }
            }
            string f = new string(arr);
            return f;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a string: ");
            string input= Console.ReadLine();
            Console.WriteLine(VowelShift(input));

        }
    }
}
