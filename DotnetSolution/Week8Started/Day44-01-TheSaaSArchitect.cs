using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Week8Started
{
    abstract class Subscriber : IComparable<Subscriber>
    {
        // Properties
        public Guid ID { get; set; }
        public string Name { get; set; }
        public DateTime JoinDate { get; set; }

        // Abstract method
        public abstract decimal CalculateMonthlyBill();

        // Equality based on ID
        public override bool Equals(object obj)
        {
            if (obj is Subscriber other)
            {
                return this.ID == other.ID;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }

        // Sorting by JoinDate then Name
        public int CompareTo(Subscriber other)
        {
            int dateCompare = JoinDate.CompareTo(other.JoinDate);

            if (dateCompare == 0)
            {
                return Name.CompareTo(other.Name);
            }

            return dateCompare;
        }
    }

    class BusinessSubscriber : Subscriber
    {
        public decimal FixedRate { get; set; }
        public decimal TaxRate { get; set; }

        public override decimal CalculateMonthlyBill()
        {
            return FixedRate * (1 + TaxRate);
        }
    }

    class ConsumerSubscriber : Subscriber
    {
        public decimal DataUsageGB { get; set; }
        public decimal PricePerGB { get; set; }

        public override decimal CalculateMonthlyBill()
        {
            return DataUsageGB * PricePerGB;
        }
    }

    class Report
    {
        public static void PrintRevenueReport(IEnumerable<Subscriber> subscribers)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("===== Revenue Report =====");
            sb.AppendLine(string.Format("{0,-15} {1,-12} {2,15}", "Name", "Type", "Monthly Bill"));
            sb.AppendLine(new string('-', 45));

            foreach (var s in subscribers)
            {
                string type = s is BusinessSubscriber ? "Business" : "Consumer";

                sb.AppendLine(string.Format("{0,-15} {1,-12} {2,15:C}",
                    s.Name,
                    type,
                    s.CalculateMonthlyBill()));
            }

            Console.WriteLine(sb.ToString());
        }
    }

    internal class TheSaaSArchitect
    {
        static void Main(string[] args)
        {
            Dictionary<string, Subscriber> subscribers =
                new Dictionary<string, Subscriber>();

            // Add 5 mixed subscribers

            subscribers.Add("alpha@corp.com",
                new BusinessSubscriber
                {
                    ID = Guid.NewGuid(),
                    Name = "Alpha Corp",
                    JoinDate = new DateTime(2023, 1, 10),
                    FixedRate = 500,
                    TaxRate = 0.18m
                });

            subscribers.Add("beta@corp.com",
                new BusinessSubscriber
                {
                    ID = Guid.NewGuid(),
                    Name = "Beta Ltd",
                    JoinDate = new DateTime(2023, 3, 5),
                    FixedRate = 700,
                    TaxRate = 0.18m
                });

            subscribers.Add("john@email.com",
                new ConsumerSubscriber
                {
                    ID = Guid.NewGuid(),
                    Name = "John",
                    JoinDate = new DateTime(2024, 2, 1),
                    DataUsageGB = 40,
                    PricePerGB = 2
                });

            subscribers.Add("emma@email.com",
                new ConsumerSubscriber
                {
                    ID = Guid.NewGuid(),
                    Name = "Emma",
                    JoinDate = new DateTime(2024, 4, 10),
                    DataUsageGB = 25,
                    PricePerGB = 2
                });

            subscribers.Add("lucas@email.com",
                new ConsumerSubscriber
                {
                    ID = Guid.NewGuid(),
                    Name = "Lucas",
                    JoinDate = new DateTime(2024, 3, 8),
                    DataUsageGB = 60,
                    PricePerGB = 2
                });

            // Sort dictionary by Monthly Bill (descending)

            var sortedSubscribers = subscribers
                .OrderByDescending(x => x.Value.CalculateMonthlyBill())
                .Select(x => x.Value)
                .ToList();

            // Generate report

            Report.PrintRevenueReport(sortedSubscribers);
        }
    }
}
