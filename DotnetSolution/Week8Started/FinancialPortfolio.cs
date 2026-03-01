namespace Week8Started
{
    public class InvalidFinancialDataException : Exception
    {
        public InvalidFinancialDataException(string message) : base(message) { }
    }
    interface IRiskAssessable
    {
        string GetRiskCategory();
    }

    interface IReportable
    {
        string GenerateReportLine();
    }

    abstract class FinancialInstruments
    {
        private decimal _quantity;
        private decimal _purchasePrice;
        private decimal _marketPrice;
        private string _currency;

        public string InstrumentId { get; set; }
        public string Name { get; set; }

        public string Currency
        {
            get => _currency;
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length != 3)
                    throw new InvalidFinancialDataException("Currency must be 3-letter code.");
                _currency = value.ToUpper();
            }
        }

        public DateTime PurchaseDate { get; set; }

        public decimal Quantity
        {
            get => _quantity;
            set
            {
                if (value < 0)
                    throw new InvalidFinancialDataException("Quantity cannot be negative.");
                _quantity = value;
            }
        }

        public decimal PurchasePrice
        {
            get => _purchasePrice;
            set
            {
                if (value < 0)
                    throw new InvalidFinancialDataException("Purchase price cannot be negative.");
                _purchasePrice = value;
            }
        }

        public decimal MarketPrice
        {
            get => _marketPrice;
            set
            {
                if (value < 0)
                    throw new InvalidFinancialDataException("Market price cannot be negative.");
                _marketPrice = value;
            }
        }

        protected FinancialInstruments(string id, string name, string currency, DateTime purchaseDate, decimal quantity,decimal purchasePrice, decimal marketPrice)
        {
            InstrumentId = id;
            Name = name;
            Currency = currency;
            PurchaseDate = purchaseDate;
            Quantity = quantity;
            PurchasePrice = purchasePrice;
            MarketPrice = marketPrice;
        }

        public abstract decimal CalculateCurrentValue();

        public virtual string GetInstrumentSummary()
        {
            return $"{InstrumentId} - {Name} ({Currency}) Value: {CalculateCurrentValue():C}";
        }

        public decimal GetInvestmentValue()
        {
            return Quantity * PurchasePrice;
        }
    }
    internal class FinancialPortfolio
    {
        static void Main(string[] args)
        {
            
        }
    }
}
