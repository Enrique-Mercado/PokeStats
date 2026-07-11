namespace PokeStatsV1.Services;
using PokeStatsV1.Models;
using System.Net.Http;
using System.Text.Json;
using PokeStatsV1.Mappers;
using PokeStatsV1.Helpers;

public class PokemonService
{
    public async Task<Pokemon> BuscarPokemon(string nombre)
    {
        //Console.WriteLine("Entré al Service");

        nombre = nombre.Trim().ToLower();

        string url = $"https://pokeapi.co/api/v2/pokemon/{nombre}";

        HttpClient cliente = new HttpClient();

        HttpResponseMessage response = await cliente.GetAsync(url);

        if(response.IsSuccessStatusCode)
        {
            string json = await response.Content.ReadAsStringAsync();

            PokemonResponse pokemonResponse =
                JsonSerializer.Deserialize<PokemonResponse>(json);

            List<HabilidadPokemon> habilidades = new();
                foreach(var ability in pokemonResponse.abilities)
                {
                    string urlHabilidad = ability.ability.url;
                    AbilityResponse abilityResponse = await ObtenerHabilidad(urlHabilidad);
                    HabilidadPokemon habilidadPokemon = new();
                    habilidadPokemon.Nombre = ability.ability.name;
                    habilidadPokemon.EsOculta = ability.is_hidden;
                    habilidadPokemon.Descripcion = PokemonHelpers.ObtenerDescripcion(abilityResponse);
                    habilidades.Add(habilidadPokemon);
                }

            Pokemon pokemon =
                PokemonMapper.Convertir(pokemonResponse, habilidades);


            return pokemon;                                                  
        }
        else
        {
            // Manejar el caso en que no se encontró el Pokémon
            return new Pokemon(); // Retorna un objeto vacío o maneja el error según sea necesario
        }
    }
    public async Task<AbilityResponse> ObtenerHabilidad(string url)
    {
        Console.WriteLine($"URL DESDE ABILITY: {url}");
        HttpClient cliente = new HttpClient();
        HttpResponseMessage response = await cliente.GetAsync(url); 
        if(response.IsSuccessStatusCode)
        {   
            string json = await response.Content.ReadAsStringAsync();
            AbilityResponse abilityResponse =
                    JsonSerializer.Deserialize<AbilityResponse>(json);

            foreach (var entry in abilityResponse.effect_entries)
            {
                Console.WriteLine($"{entry.language.name} -> {entry.effect}");
            }
        
            Console.WriteLine("JSON recibido" + abilityResponse.GetType() + url);
        return abilityResponse;                                                
        }
        else
        {
            // Manejar el caso en que no se encontró el Pokémon
            return new AbilityResponse(); // Retorna un objeto vacío o maneja el error según sea necesario
        }
    }


}



