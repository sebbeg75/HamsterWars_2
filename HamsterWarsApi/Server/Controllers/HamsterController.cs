using HamsterWarsApi.Server.Repositories.Contracts;
using HamsterWarsApi.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace HamsterWarsApi.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HamsterController : ControllerBase
{
    private readonly IHamsterRepository _hamsterRepository;

    public HamsterController(IHamsterRepository hamsterRepository)
    {
       _hamsterRepository = hamsterRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Hamster>>> GetAllHamsters()
    {
        try
        {
            var hamsters = await _hamsterRepository.GetAllHamsters();

            if (hamsters is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(hamsters);
            }
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                                "Error retrieving data from the database");
        }
    }

    [HttpPost]
    public async Task<ActionResult> AddHamster(Hamster hamster)
    {
        await _hamsterRepository.AddHamster(hamster);
        return Ok(hamster);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetHamsterById(int id)
    {
        var hamster = await _hamsterRepository.GetHamsterById(id);
        if (hamster is null)
        {
            return NotFound("Sorry no hamster here");
        }
        return Ok(hamster);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteHamster(int id)
    {
        var hamster = await _hamsterRepository.DeleteHamster(id);
        if (hamster is null)
        {
            return NotFound("Sorry no hamster here");
        }
        return Ok(hamster);
    }

    [HttpPut]
    public async Task<ActionResult> UpdateHamster(Hamster hamster)
    {
        await _hamsterRepository.UpdateHamster(hamster);
        if (hamster is null)
        {
            return NotFound("Sorry no hamster here");
        }
        return Ok(hamster);
    }

    [HttpGet("random")]
    public async Task<IActionResult> RandomHamsters(int number)
    {
        var hamsters = await _hamsterRepository.GetRandomHamsters(number);
        return Ok(hamsters);
    }
}
