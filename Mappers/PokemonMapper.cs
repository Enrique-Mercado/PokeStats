namespace PokeStatsV1.Mappers;

using PokeStatsV1.Models;

public static class PokemonMapper
{
    public static Pokemon Convertir(PokemonResponse respuesta, List<HabilidadPokemon> habilidades)
    {
        //Console.WriteLine($"Cantidad de stats: {respuesta.stats.Count}");
        Pokemon pokemon = new Pokemon();

        pokemon.Nombre = respuesta.name;
        pokemon.NumeroPokedex = respuesta.id;
        pokemon.Imagen = respuesta.sprites.front_default;
        pokemon.Tipo = string.Join(", ", respuesta.types.Select(t => t.type.name));
        pokemon.HP = respuesta.stats.FirstOrDefault(s => s.stat.name == "hp")?.base_stat ?? 0;
        pokemon.Ataque = respuesta.stats.FirstOrDefault(s => s.stat.name == "attack")?.base_stat ?? 0;
        pokemon.Defensa = respuesta.stats.FirstOrDefault(s => s.stat.name == "defense")?.base_stat ?? 0;
        pokemon.AtaqueEspecial = respuesta.stats.FirstOrDefault(s => s.stat.name == "special-attack")?.base_stat ?? 0;
        pokemon.DefensaEspecial = respuesta.stats.FirstOrDefault(s => s.stat.name == "special-defense")?.base_stat ?? 0;
        pokemon.Velocidad = respuesta.stats.FirstOrDefault(s => s.stat.name == "speed")?.base_stat ?? 0;
        pokemon.ClaseColor = respuesta.types.FirstOrDefault()?.type.name ?? "normal";
        pokemon.ClaseHeader = $"pokemon-header-{pokemon.ClaseColor}";
        pokemon.ClaseBarra = $"pokemon-bar-{pokemon.ClaseColor}";
        pokemon.ClaseColor = $"pokemon-{pokemon.ClaseColor}";
        pokemon.Tipos = respuesta.types.Select(t => t.type.name).ToList();
        pokemon.Habilidades = habilidades;

        //pokemon.DescripcionHabilidad = descripcion?.effect ?? "";
  
        

        //Console.WriteLine($"HP: {pokemon.HP}");
        //Console.WriteLine($"Ataque: {pokemon.Ataque}");
        //Console.WriteLine($"Defensa: {pokemon.Defensa}");
        //Console.WriteLine($"Clase CSS: {pokemon.ClaseHeader}");
        Console.WriteLine($"Descr Habili: { pokemon.DescripcionHabilidad}");


        return pokemon;
    }
}