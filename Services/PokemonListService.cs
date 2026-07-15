
namespace PokeStatsV1.Services;
using PokeStatsV1.Models;
using System.Net.Http;
using System.Text.Json;
using PokeStatsV1.Mappers;
using PokeStatsV1.Helpers;

public class PokemonListService
{
public async Task<List<PokemonItem>> ObtenerListaPokemon()
{
    using (var httpClient = new HttpClient())
    {
        var response = await httpClient.GetAsync("https://pokeapi.co/api/v2/pokemon?limit=1302");
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        var pokemonListResponse = JsonSerializer.Deserialize<PokemonListResponse>(content);

        if(response.IsSuccessStatusCode)
        {
            string json =
                await response.Content.ReadAsStringAsync();

            PokemonListResponse lista =
                JsonSerializer.Deserialize<PokemonListResponse>(json);
            /*foreach(var pokemon in lista.results)
            {
                Console.WriteLine(pokemon.name);
            }*/

            return lista.results;
        }

        

        return pokemonListResponse?.results ?? new List<PokemonItem>();

    }
}
}