using HamsterWarsApi.Shared.Models;

namespace HamsterWarsApi.Server.Repositories.Contracts;

public interface IBattleRepository
{
    Task AddAndUpdateBattle(Battle battle);
    Task<Battle> DeleteBattle(int id);
}
