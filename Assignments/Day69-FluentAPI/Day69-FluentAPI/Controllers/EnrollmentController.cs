using Day69_FluentAPI.DTOs;
using Day69_FluentAPI.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/enroll")]
public class EnrollmentController : ControllerBase
{
    private readonly AppDbContext _context;

    public EnrollmentController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult Enroll(EnrollmentDto dto)
    {
        var exists = _context.StudentCourses
            .Any(sc => sc.StudentId == dto.StudentId && sc.CourseId == dto.CourseId);

        if (exists)
            return BadRequest("Already enrolled");

        var enrollment = new StudentCourse
        {
            StudentId = dto.StudentId,
            CourseId = dto.CourseId
        };

        _context.StudentCourses.Add(enrollment);
        _context.SaveChanges();

        return Ok("Enrollment successful");
    }
}