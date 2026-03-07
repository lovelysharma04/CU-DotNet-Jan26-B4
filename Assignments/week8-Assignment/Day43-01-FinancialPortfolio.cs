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

        protected FinancialInstruments(string id, string name, string currency,
            DateTime purchaseDate, decimal quantity,
            decimal purchasePrice, decimal marketPrice)
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

    class Equity : FinancialInstruments, IRiskAssessable, IReportable
    {
        public Equity(string id, string name, string currency,
            DateTime purchaseDate, decimal quantity,
            decimal purchasePrice, decimal marketPrice)
            : base(id, name, currency, purchaseDate, quantity, purchasePrice, marketPrice) { }

        public override decimal CalculateCurrentValue()
            => Quantity * MarketPrice;

        public string GetRiskCategory() => "High";

        public string GenerateReportLine()
            => $"{InstrumentId},Equity,{Name},{CalculateCurrentValue():C}";
    }

    class Bond : FinancialInstruments, IRiskAssessable, IReportable
    {
        public Bond(string id, string name, string currency,
            DateTime purchaseDate, decimal quantity,
            decimal purchasePrice, decimal marketPrice)
            : base(id, name, currency, purchaseDate, quantity, purchasePrice, marketPrice) { }

        public override decimal CalculateCurrentValue()
            => Quantity * MarketPrice;

        public string GetRiskCategory() => "Low";

        public string GenerateReportLine()
            => $"{InstrumentId},Bond,{Name},{CalculateCurrentValue():C}";
    }

    class FixedDeposit : FinancialInstruments
    {
        public FixedDeposit(string id, string name, string currency,
            DateTime purchaseDate, decimal quantity,
            decimal purchasePrice, decimal marketPrice)
            : base(id, name, currency, purchaseDate, quantity, purchasePrice, marketPrice) { }

        public override decimal CalculateCurrentValue()
            => Quantity * MarketPrice;
    }

    class MutualFund : FinancialInstruments, IRiskAssessable
    {
        public MutualFund(string id, string name, string currency,
            DateTime purchaseDate, decimal quantity,
            decimal purchasePrice, decimal marketPrice)
            : base(id, name, currency, purchaseDate, quantity, purchasePrice, marketPrice) { }

        public override decimal CalculateCurrentValue()
            => Quantity * MarketPrice;

        public string GetRiskCategory() => "Medium";
    }

    class Portfolio
    {
        private List<FinancialInstruments> instruments = new();
        private Dictionary<string, FinancialInstruments> lookup = new();

        public void AddInstrument(FinancialInstruments instrument)
        {
            if (lookup.ContainsKey(instrument.InstrumentId))
                throw new InvalidFinancialDataException("Duplicate Instrument ID.");

            instruments.Add(instrument);
            lookup[instrument.InstrumentId] = instrument;
        }

        public FinancialInstruments GetInstrumentById(string id)
            => lookup.TryGetValue(id, out var inst) ? inst : null;

        public decimal GetTotalPortfolioValue()
            => instruments.Sum(i => i.CalculateCurrentValue());

        public List<FinancialInstruments> GetAll() => instruments;
    }

    class Transaction
    {
        public string TransactionId { get; set; }
        public string InstrumentId { get; set; }
        public string Type { get; set; }
        public decimal Units { get; set; }
        public DateTime Date { get; set; }
    }

    static class TransactionProcessor
    {
        public static void ProcessTransactions(Transaction[] txnArray, Portfolio portfolio)
        {
            List<Transaction> txns = txnArray.ToList();

            foreach (var txn in txns)
            {
                var instrument = portfolio.GetInstrumentById(txn.InstrumentId);
                if (instrument == null) continue;

                if (txn.Type.Equals("Buy", StringComparison.OrdinalIgnoreCase))
                {
                    instrument.Quantity += txn.Units;
                }
                else if (txn.Type.Equals("Sell", StringComparison.OrdinalIgnoreCase))
                {
                    if (txn.Units > instrument.Quantity)
                        throw new InvalidFinancialDataException("Cannot sell more units than owned.");

                    instrument.Quantity -= txn.Units;
                }
            }
        }
    }

    class ReportGenerator
    {
        public static void GenerateConsoleReport(Portfolio portfolio)
        {
            var instruments = portfolio.GetAll();

            Console.WriteLine("===== PORTFOLIO SUMMARY =====\n");

            var grouped = instruments.GroupBy(i => i.GetType().Name);

            foreach (var group in grouped)
            {
                var totalInvestment = group.Sum(i => i.GetInvestmentValue());
                var currentValue = group.Sum(i => i.CalculateCurrentValue());

                Console.WriteLine($"Instrument Type: {group.Key}");
                Console.WriteLine($"Total Investment: {totalInvestment:C}");
                Console.WriteLine($"Current Value: {currentValue:C}");
                Console.WriteLine($"Profit/Loss: {(currentValue - totalInvestment):C}\n");
            }

            Console.WriteLine($"Overall Portfolio Value: {portfolio.GetTotalPortfolioValue():C}");

            var riskDist = instruments
                .OfType<IRiskAssessable>()
                .GroupBy(r => r.GetRiskCategory())
                .Select(g => new { Risk = g.Key, Count = g.Count() });

            Console.WriteLine("Risk Distribution:");
            foreach (var r in riskDist)
                Console.WriteLine($"{r.Risk}: {r.Count}");
        }

        public static void GenerateFileReport(Portfolio portfolio)
        {
            string fileName = $"PortfolioReport_{DateTime.Now:yyyyMMdd}.txt";

            try
            {
                using StreamWriter sw = new StreamWriter(fileName);

                sw.WriteLine("===== PORTFOLIO REPORT =====");
                sw.WriteLine($"Generated: {DateTime.Now}");
                sw.WriteLine();

                foreach (var inst in portfolio.GetAll())
                {
                    if (inst is IReportable reportable)
                        sw.WriteLine(reportable.GenerateReportLine());
                    else
                        sw.WriteLine(inst.GetInstrumentSummary());
                }

                sw.WriteLine();
                sw.WriteLine($"Total Value: {portfolio.GetTotalPortfolioValue():C}");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"File error: {ex.Message}");
            }
        }
    }

    static class InstrumentFactory
    {
        public static FinancialInstruments CreateFromCsv(string csv)
        {
            var parts = csv.Split(',');

            if (parts.Length != 7)
                throw new InvalidFinancialDataException("Invalid CSV format.");

            string id = parts[0];
            string type = parts[1];
            string name = parts[2];
            string currency = parts[3];
            decimal qty = decimal.Parse(parts[4]);
            decimal purchase = decimal.Parse(parts[5]);
            decimal market = decimal.Parse(parts[6]);

            return type switch
            {
                "Equity" => new Equity(id, name, currency, DateTime.Now, qty, purchase, market),
                "Bond" => new Bond(id, name, currency, DateTime.Now, qty, purchase, market),
                "FixedDeposit" => new FixedDeposit(id, name, currency, DateTime.Now, qty, purchase, market),
                "MutualFund" => new MutualFund(id, name, currency, DateTime.Now, qty, purchase, market),
                _ => throw new InvalidFinancialDataException("Unknown instrument type.")
            };
        }
    }

    internal class FinancialPortfolio
    {
        static void Main(string[] args)
        {
            try
            {
                Portfolio portfolio = new Portfolio();

                var inst1 = InstrumentFactory.CreateFromCsv("EQ001,Equity,INFY,INR,100,1500,1650");
                var inst2 = InstrumentFactory.CreateFromCsv("BD001,Bond,GovBond,INR,50,1000,1050");

                portfolio.AddInstrument(inst1);
                portfolio.AddInstrument(inst2);

                Transaction[] txns =
                {
                    new Transaction { TransactionId="T1", InstrumentId="EQ001", Type="Buy", Units=10, Date=DateTime.Now },
                    new Transaction { TransactionId="T2", InstrumentId="BD001", Type="Sell", Units=5, Date=DateTime.Now }
                };

                TransactionProcessor.ProcessTransactions(txns, portfolio);

                ReportGenerator.GenerateConsoleReport(portfolio);
                ReportGenerator.GenerateFileReport(portfolio);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}