using HamsterWarsApi.Client.Services.Contracts;
using HamsterWarsApi.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace HamsterWarsApi.Client.Pages;

public class GalleryBase : ComponentBase
{
    [Inject]
    public IHamsterService HamsterService { get; set; }

    public IEnumerable<Hamster> Hamsters { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Hamsters = await HamsterService.GetAllHamsters();
    }
}
