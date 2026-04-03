using Day71_RazorMongo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class EditModel : PageModel
{
    private readonly LaptopService _service;

    public EditModel(LaptopService service)
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
        ModelState.Remove("Laptop.Id");

        if (!ModelState.IsValid)
            return Page();

        await _service.UpdateAsync(Laptop.Id, Laptop);

        return RedirectToPage("Index");
    }
}