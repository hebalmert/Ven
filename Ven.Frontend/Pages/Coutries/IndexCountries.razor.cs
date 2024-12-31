using Microsoft.AspNetCore.Components;
using Ven.Frontend.Repositories;
using Ven.Shared.Entities;

namespace Ven.Frontend.Pages.Coutries;

public partial class IndexCountries
{
    [Inject] private IRepository _repository { get; set; } = null!;

    public List<Country>? Countries { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await Task.Delay(3000);
        var responseHttp = await _repository.GetAsync<List<Country>>("/api/countries");
        Countries = responseHttp.Response;
    }
}