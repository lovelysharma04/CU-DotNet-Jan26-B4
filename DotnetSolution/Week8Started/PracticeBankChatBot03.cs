using System.Text.RegularExpressions;

namespace Week8Started
{
    public interface IBankAccountOperation
    {
        /* 
            Sample operations expected to be proceeded 
            Values may be different 
            -I want to see my balance 
            -I want to see money in my account 
            -I want to withdraw 200 
            -I want to pull 100 
            -I want to deposit 500 
            -I want to invest 600 
            -I want to transfer 100 to my account 
            -I want to deposit 500 dollars 
            -Pull 100 dollars 
            -Deposit 200 
        */
        void Deposit(decimal d);
        void Withdraw(decimal d);
        //returns the current balance after process. 
        decimal ProcessOperation(string message);
    }
    //Create BankOperations class by implementing IBankAccountOperation interface 
    class BankOperations : IBankAccountOperation
    {
        public decimal balance { get; set; }     
        public void Deposit(decimal d)
        {
            balance += d;
        }

        public decimal ProcessOperation(string message)
        {
            message= message.ToLower();
            var match = Regex.Match(message, @"[0-9]{1,10}(\.[0-9]{1,2}){0,1}");
            decimal amount = match.Success ? decimal.Parse(match.Value) : 0;
           
            if (message.Contains("see") || message.Contains("show"))
            {
                return balance;
            }
            else if(message.Contains("deposit") || message.Contains("put") || message.Contains("invest") || message.Contains("transfer"))
            {
                Deposit(amount);
                return balance;
            }
            else if(message.Contains("withdraw") || message.Contains("pull"))
            {
                Withdraw(amount);
                return balance;
            }
            return balance;
        }
        
        public void Withdraw(decimal d)
        {
            if (d > balance) {  balance = balance; }
            else
            {
                balance -= d;
            }
        }
    }

    internal class PracticeBankChatBot03
    {
        public static void Main(string[] args)
        {
            TextWriter textWriter =
                new StreamWriter("../../../ans.txt");

            string k = Console.ReadLine();
            int n = Convert.ToInt32(k);
            List<string> inputs = new List<string>();
            for (int i = 0; i < n; i++)
            {
                inputs.Add(Console.ReadLine());
            }
            BankOperations opt = new BankOperations();
            foreach (var item in inputs)
            {
                textWriter.WriteLine(opt.ProcessOperation(item));
            }
            textWriter.Flush();
            textWriter.Close();
        }

    }
}
