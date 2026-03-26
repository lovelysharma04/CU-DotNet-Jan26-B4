using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

[ApiController]
[Route("api/[controller]")]
public class TrackingController : ControllerBase
{
    [HttpGet("gps")]
    [Authorize] // Only checks if user is logged in
    public IActionResult GetGps()
    {
        var role = User.FindFirst(ClaimTypes.Role)?.Value;

        if (role != "Manager")
        {
            return StatusCode(403, new
            {
                message = "Access denied. Only Managers can view GPS data."
            });
        }

        var data = new[]
        {
            new { TruckId = "T1", Location = "Delhi" },
            new { TruckId = "T2", Location = "Mumbai" }
        };

        return Ok(data);
    }
}