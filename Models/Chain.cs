public class Chain
{
    public Species species { get; set; }

    public List<EvolutionDetail> evolution_details { get; set; } = new();

    public List<Chain> evolves_to { get; set; } = new();
}