using Microsoft.AspNetCore.Components;
using Ven.Frontend.Repositories;
using Ven.Shared.Entities;

namespace Ven.Frontend.Pages.Coutries;

public partial class IndexCountries
{
    [Inject] private IRepository _repository { get; set; } = null!;

    private int CurrentPage = 1;
    private int TotalPages;
    public List<Country>? Countries { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await Cargar();
    }

    private async Task SelectedPage(int page)
    {
        CurrentPage = page;
        await Cargar(page);
    }

    private async Task Cargar(int page = 1)
    {
        var responseHttp = await _repository.GetAsync<List<Country>>($"/api/countries?page={page}");
        Countries = responseHttp.Response;

        TotalPages = int.Parse(responseHttp.HttpResponseMessage.Headers.GetValues("Totalpages").FirstOrDefault()!);
    }
}