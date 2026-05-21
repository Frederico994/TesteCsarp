using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using TesteCsarp.Models;

namespace TesteCsarp.Pages
{
    public class ListadragonballModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ListadragonballModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public List<DragonBallCharacter> Personagens { get; set; } = new();

        public async Task OnGetAsync()
        {
            var client = _httpClientFactory.CreateClient("DragonBallApi");
            var response = await client.GetAsync("api/characters?limit=50");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var dados = JsonSerializer.Deserialize<DragonBallCharactersResponse>(json, options);

                Personagens = dados?.Items ?? new();
            }
        }
    }
}

