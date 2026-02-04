using System.Threading.Channels;

namespace Week5Started
{
    internal class Day25_01_TheSecureTerminal
    {
        static void Main(string[] args)
        {
            string pin = "";

            Console.Write("Enter 4-digit PIN: ");

            ConsoleKeyInfo ch;
            while( pin.Length<4)
            {
                ch = Console.ReadKey(true);
                char c =ch.KeyChar;
                if (char.IsDigit(c))
                {
                    pin += c;
                    Console.Write("*");
                }

                else if (ch.Key == ConsoleKey.Backspace)
                {
                    if (pin.Length > 0)
                    {
                        pin = pin.Substring(0, pin.Length - 1);

                        // remove last * from console
                        Console.Write("\b \b");
                    }
                    continue;
                }

            }
            Console.WriteLine();
            Console.WriteLine("PIN captured securely.");
            Console.WriteLine("Stored PIN = " + pin); 

        }
    }
}
