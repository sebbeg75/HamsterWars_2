 using HamsterWarsApi.Shared.Models;

namespace HamsterWarsApi.Server.Repositories.Contracts;

public interface IHamsterRepository
{
    List<Hamster> Hamsters { get; set; }
    Task<IEnumerable<Hamster>> GetAllHamsters();
    Task<IEnumerable<Hamster>> GetRandomHamsters(int number);
    Task<Hamster> GetHamsterById(int id);
    Task<Hamster> AddHamster(Hamster hamster);
    Task<Hamster> DeleteHamster(int id);
    Task<Hamster> UpdateHamster(Hamster hamster);
}
