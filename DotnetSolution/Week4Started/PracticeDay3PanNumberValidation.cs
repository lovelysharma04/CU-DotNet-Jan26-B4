
using System.Text.RegularExpressions;

namespace Week4Started
{
    internal class PracticeDay3PanNumberValidation
    {
        public static bool IsValid(string pan)
        {
            if (string.IsNullOrEmpty(pan))
                return false;

            if (pan.Length != 10)
                return false;

            for (int i = 0; i < 5; i++)
            {
                if (!char.IsUpper(pan[i]))
                    return false;
            }

            for (int i = 5; i < 9; i++)
            {
                if (!char.IsDigit(pan[i]))
                    return false;
            }

            if (!char.IsUpper(pan[9]))
                return false;

            return true;
        }
        static void Main(string[] args)
        {
            string pan = "ABCDE2345L";

            //if (IsValid(pan))
            //    Console.WriteLine("Valid PAN Number");
            //else
            //    Console.WriteLine("Invalid PAN Number");

            bool validPan = Regex.IsMatch(pan, @"^[A-Z]{5}[0-9]{4}[A-Z]{1}$");
            Console.WriteLine(validPan);

            string mob = "99887-76655";
            bool validMob = Regex.IsMatch(mob, @"^[7-9]{2}[0-9]{3}[-]{1}[0-9]{5}$");
            Console.WriteLine(validMob);

            string name = "Lovely";
            bool validFirstName = Regex.IsMatch(name, @"^[A-Z]{1}[a-z]{2,}$");
            Console.WriteLine(validFirstName);   // for space [ ]{1} ---------- [/s]{1}

            string fullName = "Lovely Sharma";
            bool validFullName = Regex.IsMatch(fullName, @"^[A-Z]{1}[a-z]{2,}[ ]{1}[A-Z]{1}[a-z]{2,}$");
            
        }


    }
}
