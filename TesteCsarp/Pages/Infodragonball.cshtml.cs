using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using TesteCsarp.Models;

namespace TesteCsarp.Pages
{
    public class InfodragonballModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public InfodragonballModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public DragonBallCharacterDetail Personagem { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var client = _httpClientFactory.CreateClient("DragonBallApi");
            var response = await client.GetAsync($"api/characters/{id}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var personagem = JsonSerializer.Deserialize<DragonBallCharacterDetail>(json, options);

                if (personagem != null)
                {
                    Personagem = personagem;
                }
            }

            return Page();
        }
    }
}
