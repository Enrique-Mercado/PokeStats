namespace PokeStatsV1.Models;

public class PokemonResponse
{
    public int id { get; set; }

    public string name { get; set; }

    public Sprites sprites { get; set; }

    public List<PokemonType> types { get; set; }
    
    public List<Ability> abilities { get; set; }

    public List<PokeStats> stats { get; set; }
}