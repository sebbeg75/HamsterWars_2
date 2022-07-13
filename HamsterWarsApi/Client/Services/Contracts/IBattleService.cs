using HamsterWarsApi.Shared.Models;

namespace HamsterWarsApi.Client.Services.Contracts;

public interface IBattleService
{
    Task AddAndUpdateBattle(int losserId, int winnerId);
    Task DeleteBattle(int id);
}
