namespace CSharpLearning
{
    internal class Day8thBankTransactionNarrationAnalyzer
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter <TransactionId>#<AccountHolderName>#<TransactionNarration>: ");
            string acc = Console.ReadLine();

            //Narration Normalization
            
            string[] words = acc.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            acc = string.Join(" ", words);
            acc = (acc.Trim()).ToLower();
            string[] input = acc.Split("#");
            string TransactionId = input[0];
            string AccountHolderName = input[1];
            string TransactionNarration = input[2].Trim();

            Console.WriteLine($"TransactionId: {TransactionId}");
            Console.WriteLine($"AccountHolderName: {AccountHolderName}");
            Console.WriteLine($"TransactionNarration: {TransactionNarration}");


            //Narration Comparison

            if(!(TransactionNarration.Contains("deposit") || TransactionNarration.Contains("withdrawal") || TransactionNarration.Contains("transfer")))
            {
                Console.WriteLine("NON-FINANCIAL TRANSACTION");
            }
            else if(TransactionNarration.Equals("cash deposit successful"))
            {
                Console.WriteLine("STANDARD TRANSACTION");
            }
            else if(((TransactionNarration.Contains("deposit") || TransactionNarration.Contains("withdrawal") || TransactionNarration.Contains("transfer")) && !(TransactionNarration.Equals("cash deposit successful"))))
            {
                Console.WriteLine("CUSTOM TRANSACTION");
            }
            else
            {
                Console.WriteLine("Invalid Input");
            }


        }
    }
}
