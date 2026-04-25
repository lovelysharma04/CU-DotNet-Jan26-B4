using Day71_RazorMongo.Models;
using Day71_RazorMongo.Repository;
using Microsoft.AspNetCore.Mvc;

public class LaptopController : Controller
{
    private readonly ILaptopRepository _repository;

    public LaptopController(ILaptopRepository repository)
    {
        _repository = repository;
    }

    public async Task<IActionResult> Index()
    {
        var laptops = await _repository.GetAsync();
        return View(laptops);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Laptop laptop)
    {
        if (!ModelState.IsValid)
        {
            Console.WriteLine("Model state invalid");
            return View(laptop);
        }

        Console.WriteLine("Saving to MongoDB...");

        await _repository.CreateAsync(laptop);

        TempData["Success"] = "Laptop saved!";
        return RedirectToAction(nameof(Index));

    }
}