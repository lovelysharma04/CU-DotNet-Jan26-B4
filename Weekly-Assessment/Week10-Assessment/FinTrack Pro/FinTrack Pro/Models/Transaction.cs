namespace FinTrack_Pro.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public string Category { get; set; } // e.g., Income, Expense
        public DateTime Date { get; set; }

    }
}
