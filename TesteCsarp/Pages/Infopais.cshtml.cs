using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TesteCsarp.Models;
using System.Text.Json;

namespace MyCoreApp.Pages;

public class InfopaisModel : PageModel
{
    private readonly IHttpClientFactory _httpClientFactory;

    public InfopaisModel(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public string CodigoPais { get; set; }
    public List<Pais> Paises { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(string cod)
    {
        CodigoPais = cod;
        var client = _httpClientFactory.CreateClient("RestCountries");

        if (!string.IsNullOrWhiteSpace(cod))
        {
            var response = await client.GetAsync($"v3.1/alpha/{cod}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var dados = JsonSerializer.Deserialize<List<CountryApiResponse>>(json, options);
                Paises = dados?.Select(d => new Pais
                {
                    OfficialName = d.name?.official,
                    Cca2 = d.cca2,
                    FlagUrl = d.flags?.png
                }).ToList() ?? new();
            }
        }
        else
        {
            var response = await client.GetAsync("v3.1/all");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var dados = JsonSerializer.Deserialize<List<CountryApiResponse>>(json, options);
                Paises = dados?.Select(d => new Pais
                {
                    OfficialName = d.name?.official,
                    Cca2 = d.cca2,
                    FlagUrl = d.flags?.png
                }).ToList() ?? new();
            }
        }

        return Page();
    }
}
