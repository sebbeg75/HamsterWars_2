using HamsterWarsApi.Client.Services.Contracts;
using HamsterWarsApi.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace HamsterWarsApi.Client.Pages;

public class BattleBase : ComponentBase
{
    [Inject]
    public IBattleService? BattleService { get; set; }

    [Inject]
    public IHamsterService? HamsterService { get; set; }

    public IEnumerable<Hamster>? HamsterContenders;

    public Hamster? Contender1 = new();
    public Hamster? Contender2 = new();
    public Hamster? OldContender1;
    public Hamster? OldContender2;

    protected override async Task OnInitializedAsync()
    {
        await GetContenders();
    }

    public async Task GetContenders()
    {
        int number = 2;
        HamsterContenders = await HamsterService.GetRandomHamsters(number);

        int b = 1;

        foreach (var hamster in HamsterContenders)
        {
            if (b == 1)
            {
                Contender1 = hamster;
                b++;
            }
            else
            {
                Contender2 = hamster;
            }

        }
        b = 1;
    }

    public void AddWinner(Hamster hamsterWinner)
    {
        hamsterWinner.Wins++;
        hamsterWinner.Games++;
    }

    public void AddLosser(Hamster hamsterLoser)
    {
        hamsterLoser.Losses++;
        hamsterLoser.Games++;
    }

    public async Task UpdateBattle(Hamster hamsterWinner, Hamster hamsterLoser)
    {
        AddWinner(hamsterWinner);
        AddLosser(hamsterLoser);
        await HamsterService.UpdateHamster(hamsterWinner);
        await HamsterService.UpdateHamster(hamsterLoser);
        ReloadBattle(hamsterWinner, hamsterLoser);
        await BattleService.AddAndUpdateBattle(hamsterWinner.Id, hamsterLoser.Id);
        await GetContenders();
        StateHasChanged();
    }

    public void ReloadBattle(Hamster hamsterWinner, Hamster hamsterLoser)
    {
        OldContender1 = hamsterWinner;
        OldContender2 = hamsterLoser;
    }
}
