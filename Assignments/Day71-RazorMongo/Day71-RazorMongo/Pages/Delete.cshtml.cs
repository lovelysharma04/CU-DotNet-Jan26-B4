using Day71_RazorMongo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class DeleteModel : PageModel
{
    private readonly LaptopService _service;

    public DeleteModel(LaptopService service)
    {
        _service = service;
    }

    [BindProperty]
    public Laptop Laptop { get; set; }

    public async Task OnGetAsync(string id)
    {
        Laptop = await _service.GetByIdAsync(id);
    }

    public async Task<IActionResult> OnPostAsync()
    {
        await _service.DeleteAsync(Laptop.Id);

        return RedirectToPage("Index");
    }
}