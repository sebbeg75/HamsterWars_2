using HamsterWarsApi.Client.Services.Contracts;
using HamsterWarsApi.Shared.Models;
using System.Net.Http.Json;

namespace HamsterWarsApi.Client.Services;

public class BattleService : IBattleService
{
    private readonly HttpClient _httpClient;

    public BattleService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }


    public async Task AddAndUpdateBattle(int winnerId, int loserId)
    {
        try
        {
            Battle battle = new Battle();
            battle.WinnerId = winnerId;
            battle.LoserId = loserId;

            await _httpClient.PostAsJsonAsync($"api/battle", battle);
        }
        catch (Exception)
        {

            throw;
        }
    }

    public async Task DeleteBattle(int id)
    {
        await _httpClient.DeleteAsync($"api/Battle?Id={id}");
    } 
}
