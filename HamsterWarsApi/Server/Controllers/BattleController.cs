using HamsterWarsApi.Server.Repositories.Contracts;
using HamsterWarsApi.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace HamsterWarsApi.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BattleController : ControllerBase
{
    private readonly IBattleRepository _battleRepository;

    public BattleController(IBattleRepository battleRepository)
    {
        _battleRepository = battleRepository;
    }

    [HttpPost]
    public async Task<IActionResult> AddAndUpdateBattle(Battle battle)
    {
        await _battleRepository.AddAndUpdateBattle(battle);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBattle(int id)
    {
        var battle = await _battleRepository.DeleteBattle(id);
        if (battle is null)
        {
            return NotFound("No batle here");
        }
        return Ok(battle);
    }
}
