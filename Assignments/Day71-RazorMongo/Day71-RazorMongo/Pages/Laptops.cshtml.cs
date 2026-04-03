using Day71_RazorMongo.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class IndexModel : PageModel
{
    private readonly LaptopService _service;

    public List<Laptop> Laptops { get; set; }

    public IndexModel(LaptopService service)
    {
        _service = service;
    }

    public async Task OnGetAsync()
    {
        Laptops = await _service.GetAsync();
    }
}