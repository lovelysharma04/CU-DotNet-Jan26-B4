using Day69_FluentAPI.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/courses")]
public class CoursesController : ControllerBase
{
    private readonly AppDbContext _context;

    public CoursesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAll() => Ok(_context.Courses.ToList());

    [HttpPost]
    public IActionResult Create(Course course)
    {
        _context.Courses.Add(course);
        _context.SaveChanges();
        return Created("", course);
    }
}