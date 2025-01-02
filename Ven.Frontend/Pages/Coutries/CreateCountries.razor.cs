using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Ven.Frontend.Repositories;
using Ven.Shared.Entities;

namespace Ven.Frontend.Pages.Coutries;

public partial class CreateCountries
{
    [Inject] private IRepository _repository { get; set; } = null!;
    [Inject] private NavigationManager _navigationManager { get; set; } = null!;
    [Inject] private SweetAlertService _sweetAlert { get; set; } = null!;

    private Country country = new();

    private async Task Create()
    {
        var responseHttp = await _repository.PostAsync("/api/countries", country);
        if (responseHttp.Error)
        {
            var message = await responseHttp.GetErrorMessageAsync();
            await _sweetAlert.FireAsync("Error", message, SweetAlertIcon.Error);
            return;
        }

        _navigationManager.NavigateTo("/countries");
    }

    private void Return()
    {
        _navigationManager.NavigateTo("/countries");
    }
}