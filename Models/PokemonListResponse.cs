
namespace PokeStatsV1.Models;

public class PokemonListResponse
{
    public int count { get; set; }

    public List<PokemonItem> results { get; set; } = new();
}