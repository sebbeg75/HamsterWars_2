using HamsterWarsApi.Client.Services.Contracts;
using HamsterWarsApi.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace HamsterWarsApi.Client.Pages;

public class HamsterInfoBase : ComponentBase
{
    [Inject]
    public IHamsterService HamsterService { get; set; }

    [Parameter]
    public int Id { get; set; }

    public Hamster hamster = new Hamster();

    protected override async Task OnInitializedAsync()
    {
        hamster = await HamsterService.GetHamsterById(Id);
    }
}
