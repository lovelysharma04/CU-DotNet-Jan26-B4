using Microsoft.AspNetCore.Mvc;
using VagabondMVC.Models;
using VagabondMVC.Services;

public class TravelController : Controller
{
    private readonly IDestinationService _service;

    public TravelController(IDestinationService service)
    {
        _service = service;
    }

    // GET ALL
    public async Task<IActionResult> Index()
    {
        var data = await _service.GetAllAsync();
        return View(data);
    }

    // CREATE (GET)
    public IActionResult Create()
    {
        return View();
    }

    // CREATE (POST)
    [HttpPost]
    public async Task<IActionResult> Create(Destination model)
    {
        await _service.CreateAsync(model);
        return RedirectToAction("Index");
    }

    // DETAILS
    public async Task<IActionResult> Details(int id)
    {
        var data = await _service.GetByIdAsync(id);
        return View(data);
    }

    // EDIT (GET)
    public async Task<IActionResult> Edit(int id)
    {
        var data = await _service.GetByIdAsync(id);
        return View(data);
    }

    // EDIT (POST)
    [HttpPost]
    public async Task<IActionResult> Edit(Destination model)
    {
        await _service.UpdateAsync(model);
        return RedirectToAction("Index");
    }

    // DELETE (GET)
    public async Task<IActionResult> Delete(int id)
    {
        var data = await _service.GetByIdAsync(id);
        return View(data);
    }

    // DELETE (POST)
    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _service.DeleteAsync(id);
        return RedirectToAction("Index");
    }
}
