namespace CSharpLearning
{
    internal class UserLoginMessageProcessor
    {
        static void Main(string[] args)
        {
            Console.Write("Enter <UserName>|<LoginMessage>: ");
            string s = Console.ReadLine();
            s = s.Trim();
            string[] user = s.Split('|');
            string UserName = user[0];
            string LoginMessage = user[1];
            LoginMessage = LoginMessage.ToLower();

            if (!LoginMessage.Contains("successful"))
            {
                Console.WriteLine($"User: {UserName}");
                Console.WriteLine($"Message: {LoginMessage}");
                Console.WriteLine("Status: LOGIN FAILED");
            }
            else if(LoginMessage.Equals("login successful"))
            {
                Console.WriteLine($"User: {UserName}");
                Console.WriteLine($"Message: {LoginMessage}");
                Console.WriteLine("Status: LOGIN SUCCESS");
            }
            else if((LoginMessage.Contains("successful") && !LoginMessage.Equals("login successful")))
            {
                Console.WriteLine($"User: {UserName}");
                Console.WriteLine($"Message: {LoginMessage}");
                Console.WriteLine("Status: LOGIN SUCCESS (CUSTOM MESSAGE)");
            }
            else
            {
                Console.WriteLine("Invalid Input....");
            } 

        }
    }
}
