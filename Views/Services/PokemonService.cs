namespace PokeStatsV1.Services;
using PokeStatsV1.Models;
using System.Net.Http;
using System.Text.Json;

public class PokemonService
{
    public async Task<Pokemon> BuscarPokemon(string nombre)
    {
        nombre = nombre.Trim().ToLower();

        string url = $"https://pokeapi.co/api/v2/pokemon/{nombre}";

        HttpClient cliente = new HttpClient();
        HttpResponseMessage respuesta = await cliente.GetAsync(url);
        if (respuesta.IsSuccessStatusCode)
        {
            string json = await respuesta.Content.ReadAsStringAsync();
            // Procesar el JSON y crear un objeto Pokemon 
            Console.WriteLine(json);
            PokemonResponse respuestaApi =
            JsonSerializer.Deserialize<PokemonResponse>(json);      
        else
        {
            // Manejar el caso en que no se encontró el Pokémon
            return new Pokemon(); // Retorna un objeto vacío o maneja el error según sea necesario
        }
    }
}

