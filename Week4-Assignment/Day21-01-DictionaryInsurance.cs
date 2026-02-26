namespace Week4Started
{
    public class Policy
    {
        public string HolderName { get; set; }
        public decimal Premium { get; set; }
        public int RiskScore { get; set; }
        public DateTime RenewalDate { get; set; }

        public Policy(string holderName, decimal premium, int riskScore, DateTime renewalDate)
        {
            HolderName = holderName;
            Premium = premium;
            RiskScore = riskScore;
            RenewalDate = renewalDate;
        }

        public override string ToString()
        {
            return $"Holder: {HolderName}, Premium: {Premium:C}, Risk: {RiskScore}, Renewal: {RenewalDate:d}";
        }
    }

    public class PolicyTracker
    {
        private Dictionary<string, Policy> policies = new Dictionary<string, Policy>();

        public void AddPolicy(string policyId, Policy policy)
        {
            policies[policyId] = policy;
        }

        public void BulkAdjustment()
        {
            foreach (var policy in policies.Values)
            {
                if (policy.RiskScore > 75)
                {
                    policy.Premium *= 1.05m;
                }
            }
        }

        public void CleanupOldPolicies()
        {
            List<string> keysToRemove = new List<string>();
            DateTime cutoffDate = DateTime.Now.AddYears(-3);

            foreach (var kvp in policies)
            {
                if (kvp.Value.RenewalDate < cutoffDate)
                {
                    keysToRemove.Add(kvp.Key);
                }
            }

            foreach (var key in keysToRemove)
            {
                policies.Remove(key);
            }
        }

        public string GetPolicy(string policyId)
        {
            if (policies.TryGetValue(policyId, out Policy policy))
            {
                return policy.ToString();
            }
            return "Policy Not Found.";
        }

        public void DisplayAll()
        {
            foreach (var kvp in policies)
            {
                Console.WriteLine($"ID: {kvp.Key} -> {kvp.Value}");
            }
        }
    }
    internal class Day21_01_DictionaryInsurance
    {
        static void Main(string[] args)
        {
            PolicyTracker tracker = new PolicyTracker();

            tracker.AddPolicy("P1001", new Policy("Aman", 1000m, 80, DateTime.Now.AddYears(-1)));
            tracker.AddPolicy("P1002", new Policy("Riya", 1200m, 60, DateTime.Now.AddYears(-4)));
            tracker.AddPolicy("P1003", new Policy("Karan", 900m, 90, DateTime.Now));

            tracker.DisplayAll();
            tracker.BulkAdjustment();
            tracker.CleanupOldPolicies();
            tracker.DisplayAll();
            Console.WriteLine(tracker.GetPolicy("P1001"));
            Console.WriteLine(tracker.GetPolicy("P9999"));
        }
    }
}
