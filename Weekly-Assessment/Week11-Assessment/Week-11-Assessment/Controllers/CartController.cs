using Microsoft.AspNetCore.Mvc;
using Week_11_Assessment.Services;

namespace Week_11_Assessment.Controllers
{
    public class CartController : Controller
    {
        private IPricingService _pricingService { get; set; }
        public CartController(IPricingService pricingService)
        {
            _pricingService = pricingService;
        }
        public IActionResult Index()
        {
            decimal cartTotal = 200;
            string promoCode = "FREESHIP";

            var finalTotal = _pricingService.CalculatePrice(cartTotal, promoCode);
            ViewBag.CartTotal = cartTotal;
            ViewBag.Total = finalTotal;
            return View();
        }
    }
}
