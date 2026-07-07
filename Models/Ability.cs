namespace PokeStatsV1.Models;

public class Ability
{
    public AbilityInfo ability { get; set; }

    public bool is_hidden { get; set; }

    public int slot { get; set; }
}