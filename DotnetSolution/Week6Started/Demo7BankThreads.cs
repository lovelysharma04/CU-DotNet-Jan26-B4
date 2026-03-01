namespace Week6Started
{
    class BankAccount
    {
        object lockObj = new object();
        public int Balance { get; set; }
        public BankAccount(int initialBal)
        {
            Balance=initialBal;
        }
        public void Withdraw(int amt, string tname)
        {
            lock (lockObj)
            {
                int amount = (int)amt;
                if (Balance >= amount)
                {
                    Console.WriteLine("Withdraw can be done");
                    Thread.Sleep(2000);
                    Balance -= amount;
                    Console.WriteLine($"Transaction successful for {tname}");
                }
                else
                {
                    Console.WriteLine($"No sufficient balance available..{tname}");
                }
            }
        }
    }
    internal class Demo7BankThreads
    {
        static void Main(string[] args)
        {
            BankAccount acc1 = new BankAccount(1000);

            ThreadStart ts1 = new ThreadStart(() => acc1.Withdraw(750,"Thread1"));

            //ParameterizedThreadStart pt1= new ParameterizedThreadStart(acc1.);
            //pts1(10);

            Thread t1 = new Thread(ts1);
            Thread t2 = new Thread(()=>acc1.Withdraw(750,"Thread2"));
            //Thread t2 = new Thread(() => acc1.Withdraw(750));
            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();

            //acc1.Withdraw(750);
            //acc1.Withdraw(750);

            Console.WriteLine(acc1.Balance);
        }
    }
}
