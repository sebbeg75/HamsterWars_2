using HamsterWarsApi.Server.Data;
using HamsterWarsApi.Server.Repositories.Contracts;
using HamsterWarsApi.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace HamsterWarsApi.Server.Repositories;

public class HamsterRepository : IHamsterRepository
{
    private readonly HamsterWars2DbContext _hamsterWars2DbContext;

    public HamsterRepository(HamsterWars2DbContext hamsterWars2DbContext)
    {
        _hamsterWars2DbContext = hamsterWars2DbContext;
    }

    public List<Hamster> Hamsters { get; set; } = new List<Hamster>();

    public async Task<IEnumerable<Hamster>> GetAllHamsters()
    {
        var hamsters = await _hamsterWars2DbContext.Hamsters.ToListAsync();
        return hamsters;
    }

    public async Task<Hamster> GetHamsterById(int id)
    {
        var hamster = await _hamsterWars2DbContext.Hamsters.FindAsync(id);
        if (hamster is null)
            throw new Exception("Sorry no hamster here.");
        return hamster;
    }

    public async Task<Hamster> AddHamster(Hamster hamster)
    {
        _hamsterWars2DbContext.Add(hamster);
        await _hamsterWars2DbContext.SaveChangesAsync();
        return hamster;
    }

    public async Task<Hamster> DeleteHamster(int id)
    {
        var hamster = await _hamsterWars2DbContext.Hamsters.FindAsync(id);
        if (hamster is null)
        {
            throw new Exception("Sorry no hamster here.");
        }
        else
        {
            _hamsterWars2DbContext.Hamsters.Remove(hamster);
        }
        await _hamsterWars2DbContext.SaveChangesAsync();
        return hamster;
    }

    public async Task<Hamster> UpdateHamster(Hamster hamster)
    {
        var DbHamster = await _hamsterWars2DbContext.Hamsters.FindAsync(hamster.Id);

        DbHamster.Name = hamster.Name;
        DbHamster.Age = hamster.Age;
        DbHamster.FavFood = hamster.FavFood;
        DbHamster.Loves = hamster.Loves;
        DbHamster.ImgName = hamster.ImgName;
        DbHamster.Wins = hamster.Wins;
        DbHamster.Losses = hamster.Losses;
        DbHamster.Games = hamster.Games;

        await _hamsterWars2DbContext.SaveChangesAsync();
        return hamster;
    }

    public async Task<IEnumerable<Hamster>> GetRandomHamsters(int number)
    {
        List<Hamster> hamsterList = new List<Hamster>();
        var hamster = await _hamsterWars2DbContext.Hamsters.ToListAsync();

        var hamsters = hamster.OrderBy(h => Guid.NewGuid()).Take(number).ToList();
        return hamsters;
    }
}
