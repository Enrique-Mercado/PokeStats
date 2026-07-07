namespace PokeStatsV1.Mappers;

using PokeStatsV1.Models;

public static class PokemonMapper
{
    public static Pokemon Convertir(PokemonResponse respuesta)
    {
         Console.WriteLine($"Cantidad de stats: {respuesta.stats.Count}");

        foreach (var stat in respuesta.stats)
        {
            Console.WriteLine($"{stat.stat.name} = {stat.base_stat}");
        }




        Pokemon pokemon = new Pokemon();

        pokemon.Nombre = respuesta.name;
        pokemon.NumeroPokedex = respuesta.id;
        pokemon.Imagen = respuesta.sprites.front_default;
        pokemon.Tipo = string.Join(", ", respuesta.types.Select(t => t.type.name));
        pokemon.Habilidad = string.Join(", ", respuesta.abilities.Select(a => a.ability.name));
        pokemon.HP = respuesta.stats.FirstOrDefault(s => s.stat.name == "hp")?.base_stat ?? 0;
        pokemon.Ataque = respuesta.stats.FirstOrDefault(s => s.stat.name == "attack")?.base_stat ?? 0;
        pokemon.Defensa = respuesta.stats.FirstOrDefault(s => s.stat.name == "defense")?.base_stat ?? 0;
        pokemon.AtaqueEspecial = respuesta.stats.FirstOrDefault(s => s.stat.name == "special-attack")?.base_stat ?? 0;
        pokemon.DefensaEspecial = respuesta.stats.FirstOrDefault(s => s.stat.name == "special-defense")?.base_stat ?? 0;
        pokemon.Velocidad = respuesta.stats.FirstOrDefault(s => s.stat.name == "speed")?.base_stat ?? 0;
        


        Console.WriteLine($"HP: {pokemon.HP}");
        Console.WriteLine($"Ataque: {pokemon.Ataque}");
        Console.WriteLine($"Defensa: {pokemon.Defensa}");


        return pokemon;
    }
}