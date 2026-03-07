namespace Week4Started
{

     abstract class Loan
    {
        public string LoanNumber { get; set; }
        public string CustomerName { get; set; }
        public decimal PrincipalAmount { get; set; }
        public int TenureInYears { get; set; }

        public Loan()
        {
            LoanNumber=string.Empty;
            CustomerName=string.Empty;
            PrincipalAmount = 0m;
            TenureInYears=0;
        }

        public Loan(string loanNumber, string customerName, decimal principleAmount, int tenureInYear)
        {
            LoanNumber= loanNumber;
            CustomerName= customerName;
            PrincipalAmount= principleAmount;
            TenureInYears= tenureInYear;
        }
        public virtual decimal CalculateEMI()
        {
            decimal si = (PrincipalAmount * 10 * TenureInYears) / 100;
            decimal toPayAnnual = si + PrincipalAmount;
            return toPayAnnual / (12 * TenureInYears);
        }

    }
    class HomeLoan: Loan
    {
        public HomeLoan(string loanNumber, string customerName, decimal principleAmount, int tenureInYear)
        {
            LoanNumber = loanNumber;
            CustomerName = customerName;
            PrincipalAmount = principleAmount;
            TenureInYears = tenureInYear;
        }
        public override decimal CalculateEMI()
        {
            Console.Write("HOME LOAN: ");
            decimal si = (PrincipalAmount * 8 * TenureInYears) / 100;
            decimal processingfee = 1 * PrincipalAmount / 100;
            decimal toPayAnnual = si + PrincipalAmount +processingfee;
            return toPayAnnual / (12 * TenureInYears);
        }
    }
    class CarLoan: Loan
    {
        public CarLoan(string loanNumber, string customerName, decimal principleAmount, int tenureInYear)
        {
            LoanNumber = loanNumber;
            CustomerName = customerName;
            PrincipalAmount = principleAmount;
            TenureInYears = tenureInYear;
        }
        public override decimal CalculateEMI()
        {
            Console.Write("CAR LOAN: ");
            decimal si = (PrincipalAmount * 9 * TenureInYears) / 100;
            decimal toPayAnnual = si + PrincipalAmount + 15000;
            return toPayAnnual / (12 * TenureInYears);
        }
    }
    internal class Demo2Inheritance
    {
        static void Main(string[] args)
        {
            //Loan l = new Loan();
            Loan[] loan = new Loan[2];
            HomeLoan l1 = new HomeLoan("001","Lovely",10000,2);
            CarLoan l2 = new CarLoan("002","Nitin",10000,3);
            loan[0] = l1;
            loan[1] = l2;
            for (int i = 0; i < loan.Length; i++)
            {
                Console.WriteLine($"{loan[i].CalculateEMI():F2}"); 
            }

            //Loan[] loan = new Loan[2]      Anonymous object
            //{
            //    new HomeLoan(),
            //    new CarLoan()
            //};

        }
    }
}
