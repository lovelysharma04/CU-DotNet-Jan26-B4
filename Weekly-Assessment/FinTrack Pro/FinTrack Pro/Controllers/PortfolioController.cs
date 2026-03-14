using FinTrack_Pro.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinTrack_Pro.Controllers
{
    public class PortfolioController : Controller
    {
        private static List<Asset> assets = new List<Asset>
        {
            new Asset { Id=1, Name="Gold", Price=300000, Quantity=5 },
            new Asset { Id=2, Name="Tesla", Price=1200000, Quantity=2 }
        };
        //GET Index
        public IActionResult Index()
        {
            return View(assets);
        }
         //GET Details
        [Route("Asset/Info/{id:int}")]
        public IActionResult Details(int id)
        {
            var asset = assets.FirstOrDefault(a => a.Id == id);

            return View(asset);
        }

        //GET Delete
        public IActionResult Delete(int id)
        {
            var asset = assets.FirstOrDefault(a => a.Id == id);

            if (asset != null)
            {
                assets.Remove(asset);

                TempData["Message"] = "Asset Deleted Successfully!";
            }

            return RedirectToAction("Index");
        }
    }
}
