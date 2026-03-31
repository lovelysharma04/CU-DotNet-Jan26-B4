namespace Week_11_Assessment.Services
{
    public interface IPricingService
    {
        decimal CalculatePrice(decimal basePrice, string promoCode);
    }
}
