using Microsoft.AspNetCore.Mvc;
using Week_11_Assessment.Services;

namespace Week_11_Assessment.Controllers
{
    public class ProductsController : Controller
    {
        private IPricingService _pricingService { get; set; }
        public ProductsController(IPricingService pricingService)
        {
            _pricingService = pricingService;
        }
        public IActionResult Index()
        {
            decimal basePrice = 100;
            string promoCode = "WINTER25";

            var discountedPrice = _pricingService.CalculatePrice(basePrice, promoCode);
            ViewBag.BasePrice = basePrice;
            ViewBag.Price = discountedPrice;
            return View();
        }
    }
}
