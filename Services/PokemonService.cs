namespace PokeStatsV1.Services;
using PokeStatsV1.Models;
using System.Net.Http;
using System.Text.Json;
using PokeStatsV1.Mappers;

public class PokemonService
{
    public async Task<Pokemon> BuscarPokemon(string nombre)
    {
        Console.WriteLine("Entré al Service");

        nombre = nombre.Trim().ToLower();

        string url = $"https://pokeapi.co/api/v2/pokemon/{nombre}";

        HttpClient cliente = new HttpClient();

        HttpResponseMessage response = await cliente.GetAsync(url);

        if(response.IsSuccessStatusCode)
        {
            string json = await response.Content.ReadAsStringAsync();

            PokemonResponse pokemonResponse =
                JsonSerializer.Deserialize<PokemonResponse>(json);

            Pokemon pokemon =
                PokemonMapper.Convertir(pokemonResponse);

            Console.WriteLine("JSON recibido");

            return pokemon;
        }
        else
        {
            // Manejar el caso en que no se encontró el Pokémon
            return new Pokemon(); // Retorna un objeto vacío o maneja el error según sea necesario
        }
    }
}
