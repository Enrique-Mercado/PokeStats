
namespace PokeStatsV1.Models;

public class PokemonViewModel
{
    public Pokemon Pokemon { get; set; } = new();

    public List<PokemonItem> ListaPokemon { get; set; } = new();
}