using SmartBankMiniProject.Models;

namespace SmartBankMiniProject.DTOs
{
    public class CreateAccountDto
    {
        public string Name { get; set; }
        public decimal InitialDeposit { get; set; }
        public AccountCategory Category { get; set; }
    }
}
