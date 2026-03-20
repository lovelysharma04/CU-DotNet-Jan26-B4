namespace Day62_02_LoanManagementwithDTOs.DTOs
{
    public class LoanCreateDto
    {
        public string BorrowerName { get; set; }
        public decimal Amount { get; set; }
        public int LoanTermMonths { get; set; }
    }
}
