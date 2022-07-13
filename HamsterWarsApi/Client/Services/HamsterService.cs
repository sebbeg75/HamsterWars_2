using HamsterWarsApi.Client.Services.Contracts;
using HamsterWarsApi.Shared.Models;
using System.Net.Http.Json;

namespace HamsterWarsApi.Client.Services;

public class HamsterService : IHamsterService
{
    private readonly HttpClient _httpClient;

    public HamsterService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public List<Hamster> Hamsters { get; set; } = new List<Hamster>();

    public async Task<IEnumerable<Hamster>> GetAllHamsters()
    {
        try
        {
            var hamsters = await _httpClient.GetFromJsonAsync<IEnumerable<Hamster>>("api/Hamster");
            return hamsters;
        }
        catch (Exception)
        {

            throw;
        }
    }

    public async Task<Hamster> GetHamsterById(int id)
    {
        try
        {
            var hamsterId = await _httpClient.GetFromJsonAsync<Hamster>($"api/hamster/{id}");
            return hamsterId;
        }
        catch (Exception)
        {

            throw new Exception("Sorry no hamster here");
        }
    }

    public async Task<IEnumerable<Hamster>> GetRandomHamsters(int number)
    {
        var result = await _httpClient.GetFromJsonAsync<List<Hamster>>($"api/hamster/random?number={number}");
        if (result != null)
            Hamsters = result;
        return Hamsters;
    }

    public async Task AddHamster(Hamster hamster)
    {
        await _httpClient.PostAsJsonAsync("api/Hamster", hamster);
    }

    public async Task DeleteHamster(int id)
    {
        await _httpClient.DeleteAsync($"api/Hamster/{id}");
    }

    public async Task UpdateHamster(Hamster hamster)
    {
        await _httpClient.PutAsJsonAsync("api/hamster", hamster);
    }
}
 