using Ven.Shared.Entities;

namespace Ven.AccessData.Data;

public class SeedDb
{
    private readonly DataContext _context;

    public SeedDb(DataContext context)
    {
        _context = context;
    }

    public async Task SeedAsync()
    {
        await _context.Database.EnsureCreatedAsync();
        await CheckCountriesAsync();
    }

    private async Task CheckCountriesAsync()
    {
        if (!_context.Countries.Any())
        {
            _context.Countries.AddRange(new List<Country>()
            {
                new Country { Name = "Andorra"},
                new Country { Name = "Belgica"},
                new Country { Name = "Canada"},
                new Country { Name = "Colombia"},
                new Country { Name = "Estados Unidos"},
                new Country { Name = "Dinamarca"},
                new Country { Name = "Honduras"},
                new Country { Name = "Nicaragua"},
                new Country { Name = "Belorusia"},
                new Country { Name = "Rusia"},
                new Country { Name = "China"},
                new Country { Name = "Corea"},
                new Country { Name = "Reino Unido"},
                new Country { Name = "Italia"},
                new Country { Name = "Espana"},
                new Country { Name = "Suiza"}
            });
            await _context.SaveChangesAsync();
        }
    }
}