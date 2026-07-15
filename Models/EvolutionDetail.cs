
public class EvolutionDetail
{
    public int? min_level { get; set; }

    public Item item { get; set; }

    public Trigger trigger { get; set; }

    public int? min_happiness { get; set; }

    public string time_of_day { get; set; }

    public int? min_affection { get; set; }

    public int? min_beauty { get; set; }

    public NamedApiResource known_move { get; set; }

    public NamedApiResource known_move_type { get; set; }

    public NamedApiResource held_item { get; set; }

    public int? gender { get; set; }
    public int? relative_physical_stats { get; set; }

    public bool? needs_overworld_rain { get; set; }

    public bool? turn_upside_down { get; set; }

    public NamedApiResource party_species { get; set; }

    public NamedApiResource location { get; set; }
}