
namespace Week4Started
{
    abstract class UtilityBill
    {
        public int ConsumerId { get; set; }
        public string ConsumerName { get; set; }
        public decimal UnitsConsumed { get; set; }
        public decimal RatePerUnit { get; set; }
        public abstract decimal CalculateBillAmount();
        public virtual decimal CalculateTax(decimal billAmount)
        {
            decimal tax = 0.05m * billAmount;
            return tax;
        }
        protected UtilityBill(int cId, string cName, decimal units, decimal ratePerUnit) 
        {
            ConsumerId = cId;
            ConsumerName = cName;
            UnitsConsumed = units;
            RatePerUnit = ratePerUnit;       
        }
        public void PrintBill()
        {
            Console.WriteLine($"Consumer Id: {ConsumerId}");
            Console.WriteLine($"Name: {ConsumerName}");
            Console.WriteLine($"No. of Units Consumed: {UnitsConsumed}");
            Console.WriteLine($"Bill(without tax): {CalculateBillAmount()}");
            decimal d = CalculateBillAmount();
            decimal t= CalculateTax(d);
            Console.WriteLine($"Tax Amount: {t}");
            Console.WriteLine($"Total Amount(Including tax): {t+ CalculateBillAmount()}");
        }

    }
    class ElectricityBill: UtilityBill
    {
        public ElectricityBill(int cId, string cName, decimal units, decimal ratePerUnit):base(cId, cName, units, ratePerUnit){}
        public override decimal CalculateBillAmount() {
            if (UnitsConsumed > 300)
            {
                return (0.1m * UnitsConsumed * RatePerUnit)+ UnitsConsumed * RatePerUnit;
            }
            return UnitsConsumed * RatePerUnit; 
        }
    }
    class WaterBill : UtilityBill
    {
        public WaterBill(int cId, string cName, decimal units, decimal ratePerUnit) : base(cId, cName, units, ratePerUnit) { }
        public override decimal CalculateBillAmount()
        {
            return UnitsConsumed * RatePerUnit;
        }
        public override decimal CalculateTax(decimal billAmount)
        {
            decimal tax = 0.02m * billAmount;
            return tax;
        }
    }
    class GasBill : UtilityBill
    {
        public GasBill(int cId, string cName, decimal units, decimal ratePerUnit) : base(cId, cName, units, ratePerUnit) { }
        public override decimal CalculateBillAmount()
        {
            return UnitsConsumed*RatePerUnit + 150;
        }
        public override decimal CalculateTax(decimal billAmount)
        {
            decimal tax = 0m;
            return tax;
        }
    }

    internal class Day19_02_AbstractOverride
    {
        static void Main(string[] args)
        {
            ElectricityBill e = new ElectricityBill(01,"Lovely",301,9);
            WaterBill w = new WaterBill(02, "Lovely", 2000, 8);
            GasBill g = new GasBill(03, "Lovely", 100, 7);
            List<UtilityBill> l = new List<UtilityBill>();
            l.Add(e);
            l.Add(w);
            l.Add(g);
            foreach (var items in l)
            {
                items.PrintBill();
                Console.WriteLine();
            }
        }
    }
}
