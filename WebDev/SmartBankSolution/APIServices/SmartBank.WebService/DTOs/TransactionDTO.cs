namespace WebApplicationMVC.DTOs
{
    public class TransactionDTO
    {
        public int AccountId { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedAt { get; set; }
        public int TransactionId { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
    }
}