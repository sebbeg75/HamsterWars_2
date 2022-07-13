using HamsterWarsApi.Shared.Models;

namespace HamsterWarsApi.Client.Services.Contracts;

public interface IHamsterService
{
    List<Hamster> Hamsters { get; set; }
    Task<IEnumerable<Hamster>> GetAllHamsters();
    Task<IEnumerable<Hamster>> GetRandomHamsters(int number);
    Task<Hamster> GetHamsterById(int id);
    Task DeleteHamster(int id);
    Task AddHamster(Hamster hamster);
    Task UpdateHamster(Hamster hamster);
}
