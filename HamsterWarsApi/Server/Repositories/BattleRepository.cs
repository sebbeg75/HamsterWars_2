using HamsterWarsApi.Server.Data;
using HamsterWarsApi.Server.Repositories.Contracts;
using HamsterWarsApi.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace HamsterWarsApi.Server.Repositories;

public class BattleRepository : IBattleRepository
{
    private readonly HamsterWars2DbContext _hamsterWars2DbContext;

    public BattleRepository(HamsterWars2DbContext hamsterWars2DbContext)
    {
        _hamsterWars2DbContext = hamsterWars2DbContext;
    }

    public async Task AddAndUpdateBattle(Battle battle)
    {
        _hamsterWars2DbContext.AddAsync(battle);
        await _hamsterWars2DbContext.SaveChangesAsync();
    }

    public async Task<Battle> DeleteBattle(int id)
    {
        var battle = await _hamsterWars2DbContext.Battles.FindAsync(id);

        if (battle is null)
        {
            throw new Exception("Sorry no battle here.");
        }
        else
        {
            _hamsterWars2DbContext.Battles.Remove(battle);
        }
        await _hamsterWars2DbContext.SaveChangesAsync();
        return battle;
    }
}
