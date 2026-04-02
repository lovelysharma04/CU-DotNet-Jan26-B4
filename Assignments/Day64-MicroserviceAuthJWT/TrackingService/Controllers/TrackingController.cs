using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

[ApiController]
[Route("api/[controller]")]
public class TrackingController : ControllerBase
{
    [HttpGet("gps")]
    [Authorize(Roles = "Manager")]
    public IActionResult GetGps()
    {
        var gpsData = new[]
        {
            new
            {
                TruckId = "T1",
                Latitude = 28.6139,
                Longitude = 77.2090,
                Timestamp = DateTime.UtcNow
            },
            new
            {
                TruckId = "T2",
                Latitude = 19.0760,
                Longitude = 72.8777,
                Timestamp = DateTime.UtcNow
            }
        };

        return Ok(gpsData);
    }
}