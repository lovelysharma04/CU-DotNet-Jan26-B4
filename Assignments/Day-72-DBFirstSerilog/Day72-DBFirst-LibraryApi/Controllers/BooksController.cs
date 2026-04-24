using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Day72_DBFirst_LibraryApi.Data;
using Day72_DBFirst_LibraryApi.Models;

[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly LibraryDbContext _context;
    private readonly ILogger<BooksController> _logger;

    public BooksController(LibraryDbContext context, ILogger<BooksController> logger)
    {
        _context = context;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetBooks()
    {
        _logger.LogInformation("Fetching all books");

        var books = await _context.Books.Include(b => b.Author).ToListAsync();
        return Ok(books);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBook(int id)
    {
        var book = await _context.Books.Include(b => b.Author)
                                       .FirstOrDefaultAsync(b => b.Id == id);

        if (book == null)
        {
            _logger.LogWarning("Book not found");
            return NotFound();
        }

        return Ok(book);
    }

    [HttpPost]
    public async Task<IActionResult> CreateBook(Book book)
    {
        _context.Books.Add(book);
        await _context.SaveChangesAsync();

        return Ok(book);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBook(int id)
    {
        var book = await _context.Books.FindAsync(id);

        if (book == null)
        {
            _logger.LogWarning("Delete failed - not found");
            return NotFound();
        }

        _context.Books.Remove(book);
        await _context.SaveChangesAsync();

        return Ok();
    }
}