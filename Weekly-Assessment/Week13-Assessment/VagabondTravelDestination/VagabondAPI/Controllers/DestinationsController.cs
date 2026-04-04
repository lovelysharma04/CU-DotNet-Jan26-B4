using Microsoft.AspNetCore.Mvc;
using VagabondAPI.DTOs;
using VagabondAPI.Exceptions;
using VagabondAPI.Models;
using VagabondAPI.Repository;

[ApiController]
[Route("api/[controller]")]
public class DestinationsController : ControllerBase
{
    private readonly IDestinationRepository _repo;

    public DestinationsController(IDestinationRepository repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _repo.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var destination = await _repo.GetByIdAsync(id);
        if (destination == null)
            throw new DestinationNotFoundException("Destination not found");

        return Ok(destination);
    }

    //[HttpPost]
    //public async Task<IActionResult> Create(Destination destination)
    //{
    //    await _repo.AddAsync(destination);
    //    return Ok(destination);
    //}
    [HttpPost]
    public async Task<IActionResult> Create(DestinationCreateDto dto)
    {
        var destination = new Destination
        {
            CityName = dto.CityName,
            Country = dto.Country,
            Description = dto.Description,
            Rating = dto.Rating,
            LastVisited = dto.LastVisited
        };

        await _repo.AddAsync(destination);

        return CreatedAtAction(nameof(Get), new { id = destination.Id }, destination);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Destination destination)
    {
        if (id != destination.Id)
            return BadRequest();

        await _repo.UpdateAsync(destination);
        return Ok(destination);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _repo.DeleteAsync(id);
        return Ok("Deleted");
    }
}