namespace WebApplicationMVC.DTOs
{
    public class AccountDTO
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public List<TransactionDTO> Transactions { get; set; } = new();
    }
}
