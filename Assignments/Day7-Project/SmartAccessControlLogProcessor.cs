namespace CSharpLearning
{
    internal class SmartAccessControlLogProcessor
    {
        static void Main(string[] args)
        {
            //Smart Access Control Log Processor
            Console.WriteLine("Enter <GateCode>|<UserInitial>|<AccessLevel>|<IsActive>|<Attempts> (seperated by |): ");
            string[] arr = Console.ReadLine().Split("|");
            string GateCode = arr[0];
            char UserInitial = char.Parse(arr[1]);
            byte AccessLevel = byte.Parse(arr[2]);
            bool IsActive = bool.Parse(arr[3]);
            byte Attempts = byte.Parse(arr[4]);

            //Console.WriteLine($"{GateCode}|{UserInitial}|{AccessLevel}|{IsActive}|{Attempts}");
            if( GateCode.Length!=2 || !char.IsLetter(GateCode[0]) || !char.IsDigit(GateCode[1]) || !char.IsUpper(UserInitial) 
                || !(AccessLevel>1 && AccessLevel<7) || !(Attempts <= 200))
            {
                Console.WriteLine("Invalid Access Log....");
            }
            else
            { 
                if(IsActive == false) { Console.WriteLine("ACCESS DENIED – INACTIVE USER"); }
                else if(Attempts > 100) { Console.WriteLine("ACCESS DENIED – TOO MANY ATTEMPTS"); }
                else if(AccessLevel >= 5) { Console.WriteLine("ACCESS GRANTED – HIGH SECURITY"); }
                else { Console.WriteLine("ACCESS GRANTED – STANDARD"); }

            }
        }
    }
}
