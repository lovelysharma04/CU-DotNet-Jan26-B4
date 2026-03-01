using System;

namespace Week6Started
{
    internal class ExpenseSplitWiseUsingDictionary
    {
        public static List<string> SettleExpenseShare(Dictionary<string, double> expenses)
        {
            List<string> settlement = new List<string>();      //csv string

            //creditors or Debitors--------
            Queue<KeyValuePair<string,double>> receivers = new Queue<KeyValuePair<string,double>>();

            Queue<KeyValuePair<string, double>> payers = new Queue<KeyValuePair<string, double>>();

            var totalExpense = expenses.Values.Sum();
            var persons = expenses.Count;
            var share = totalExpense / persons;

            //populate payers and receivers queues
            foreach (var person in expenses)
            {
                if (person.Value > share)
                {
                    receivers.Enqueue(
                        new KeyValuePair<string, double> (person.Key, (person.Value - share))
                    );

                }
                else if(person.Value < share) 
                {
                    payers.Enqueue(
                        new KeyValuePair<string, double>(person.Key, Math.Abs(person.Value - share))
                    );
                }
            }
            //settlement
            while(payers.Count>0 && receivers.Count > 0)
            {
                var payer = payers.Dequeue();
                var receiver = receivers.Dequeue();
                var amount = Math.Min(payer.Value, receiver.Value);

                settlement.Add($"{payer.Key} will pay {amount} to {receiver.Key}");

                if (payer.Value > amount)
                {
                    payers.Enqueue(
                            new KeyValuePair<string, double>(payer.Key, Math.Abs(payer.Value - amount))
                     );
                }
                if(receiver.Value > amount)
                {
                    receivers.Enqueue(
                        new KeyValuePair<string, double>(receiver.Key, Math.Abs(receiver.Value - amount))
                    );
                }
                Console.WriteLine("Settlement Done..");

            }
            return settlement;

        }
        static void Main(string[] args)
        {
            Dictionary<string, double> expenses = new Dictionary<string, double>()
            {
                {"Aman",900},
                {"Sunil",0},
                {"Kartik",400},
                {"Nitin",200 }
            };
            List<string> list= new List<string>();
            list = SettleExpenseShare(expenses);
            Console.WriteLine(string.Join("\n", list));
        }
    }
}
