namespace PokeStatsV1.Services;
using PokeStatsV1.Models;
using System.Net.Http;
using System.Text.Json;
using PokeStatsV1.Mappers;
using PokeStatsV1.Helpers;

public class PokemonService
{
    public async Task<Pokemon> BuscarPokemon(string busqueda)
    {
        //Console.WriteLine("Entré al Service");

        busqueda = busqueda.Trim().ToLower();

        string url = $"https://pokeapi.co/api/v2/pokemon/{busqueda}";

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

            SpeciesService speciesService = new SpeciesService();
            SpeciesResponse speciesResponse = await speciesService.ObtenerSpecies(pokemonResponse.species.url);
            //Console.WriteLine(speciesResponse.evolution_chain.url);
            foreach(var forma in speciesResponse.varieties)
{
    Console.WriteLine(forma.pokemon.name);
}



            EvolutionService evolutionService = new EvolutionService();
            EvolutionResponse evolutionResponse = await evolutionService.ObtenerCadena(speciesResponse.evolution_chain.url);
            
            List<EvolucionPokemon> evoluciones =
                EvolutionMapper.Convertir(evolutionResponse);
            Console.WriteLine($"Cadena: {evoluciones.ToArray().Select(e => e.Nombre).Aggregate((a, b) => a + " -> " + b)}");
            PokemonService pokemonService = new();
            
            
            Pokemon pokemon =
                PokemonMapper.Convertir(pokemonResponse, habilidades);
            foreach(var evolucion in evoluciones)
            {
                Pokemon pokemonBasico =
                    await ObtenerPokemonBasico(evolucion.Nombre);

                evolucion.NumeroPokedex = pokemonBasico.NumeroPokedex;
                evolucion.Imagen = pokemonBasico.Imagen;

                evolucion.EsActual =
                    evolucion.Nombre.Equals(
                        pokemon.Nombre,
                        StringComparison.OrdinalIgnoreCase);
            }

            pokemon.Evoluciones = evoluciones;



            
 List<FormaPokemon> formas = new();

foreach(var variedad in speciesResponse.varieties)
{
    Pokemon pokemonForma =
        await ObtenerPokemonBasico(
            variedad.pokemon.name);

    FormaPokemon forma = new();

    forma.Nombre = pokemonForma.Nombre;
    forma.NumeroPokedex = pokemonForma.NumeroPokedex;
    forma.Imagen = pokemonForma.Imagen;
    forma.EsActual = pokemonForma.Nombre.Equals(
            pokemon.Nombre,
            StringComparison.OrdinalIgnoreCase);
    forma.EsDefault = variedad.is_default;
    FormaHelpers.Clasificar(forma);


    formas.Add(forma);
}
    
    pokemon.Formas = formas;

    Console.WriteLine("===== FORMAS =====");

foreach(var forma in pokemon.Formas)
{
    Console.WriteLine(
        $"{forma.Nombre} | {forma.NumeroPokedex} | {forma.EsDefault}");
         Console.WriteLine(
        $"{forma.NombreMostrar} | {forma.Tipo}");
}

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
        //Console.WriteLine($"URL DESDE ABILITY: {url}");
        HttpClient cliente = new HttpClient();
        HttpResponseMessage response = await cliente.GetAsync(url); 
        if(response.IsSuccessStatusCode)
        {   
            string json = await response.Content.ReadAsStringAsync();
            AbilityResponse abilityResponse =
                    JsonSerializer.Deserialize<AbilityResponse>(json);

        
            //Console.WriteLine("JSON recibido" + abilityResponse.GetType() + url);
        return abilityResponse;                                                
        }
        else
        {
            // Manejar el caso en que no se encontró el Pokémon
            return new AbilityResponse(); // Retorna un objeto vacío o maneja el error según sea necesario
        }
    }


    public async Task<Pokemon> ObtenerPokemonBasico(string nombre)
    {
        nombre = nombre.Trim().ToLower();

        string url = $"https://pokeapi.co/api/v2/pokemon/{nombre}";

        HttpClient cliente = new HttpClient();

        HttpResponseMessage response = await cliente.GetAsync(url);

        if(response.IsSuccessStatusCode)
        {

            string json = await response.Content.ReadAsStringAsync();

            PokemonResponse pokemonResponse =
                JsonSerializer.Deserialize<PokemonResponse>(json);
            Pokemon pokemon = new();

            pokemon.Nombre = pokemonResponse.name;
            pokemon.NumeroPokedex = pokemonResponse.id;
            pokemon.Imagen = pokemonResponse.sprites.front_default;
            
            return pokemon;
        }

        return new Pokemon();
    }


}



