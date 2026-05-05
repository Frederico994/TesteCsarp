using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TesteCsarp.Pages
{


    public class  ListadragonballModel : PageModel
    {
    private readonly IHttpClientFactory _httpClientFactory;

    public ListadragonballModel(IHttpClientFactory httpClientFactory)

    {
        _httpClientFactory = httpClientFactory;
    }

    public List<Listadragonball> Listadragonball { get; set; } = new();
    public async Task OnGetAsync()

    {
        //var client = _httpClientFactory.CreateClient();
        //var response = await client.GetAsync("https://dragonball-api.com/api/characters/2");
        var client = _httpClientFactory.CreateClient("RestCountries");
        var response = await client.GetAsync("https://dragonball-api.com/api/characters");

        if (response.IsSuccessStatusCode)

        {
            var json = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var dados = JsonSerializer.Deserialize<List<CountryApiResponse>>(json, options);

            Listadragonball = dados.Select(d => new Listadragonball
            {
                OfficialName = d.name?.name,
                Id = d.id,
                Image = d.image?.png
            }).ToList();
        }
    }


}
}    
    

