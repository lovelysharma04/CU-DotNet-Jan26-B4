namespace Week4Started
{
    internal class Demo9Ditcionary
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> countryCapitals = new Dictionary<string, string>();
            countryCapitals.Add("India", "Delhi");
            countryCapitals.Add("Australia", "Canberra");
            countryCapitals["Monaco"] = "Monaco";
            foreach (KeyValuePair<string, string> item in countryCapitals)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
            Console.WriteLine("\nCountries are");
            foreach (string country in countryCapitals.Keys)
            {
                Console.WriteLine(country);
            }
            Console.WriteLine("\nCapitals are");
            foreach (string capital in countryCapitals.Values)
            {
                Console.WriteLine(capital);
            }
            string con = Console.ReadLine();
            string cap = string.Empty;
            bool exiting = countryCapitals.TryGetValue(con, out cap);
            if (exiting)
            {
                countryCapitals.Add(con, cap);
            }
            else
            {
                Console.WriteLine("Not in");
            }

            string sen = "This is a sentence";
            sen = sen.ToLower();
            //int[] arr = new int[26];

            //foreach (char ch in sen)
            //{
            //    if (ch >= 'a' && ch <= 'z')
            //    {
            //        arr[ch - 'a']++;
            //    }
            //}
            //for (int i = 0; i < 26; i++)
            //{
            //    Console.WriteLine($"{(char)(i + 'a')} : {arr[i]}");
            //}
            ////Console.WriteLine(string.Join(",", arr));

            Dictionary<char, int> dict = new Dictionary<char, int>();
            foreach (char ch in sen)
            {
                if (ch >= 'a' && ch <= 'z')
                {
                    if (dict.ContainsKey(ch))
                    {
                        dict[ch] = dict[ch] + 1;
                    }
                    else
                    {
                        dict[ch] = 1;
                    }
                }

            }
            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

        }

    }
}
