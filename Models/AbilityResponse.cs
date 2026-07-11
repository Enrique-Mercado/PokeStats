public class AbilityResponse
{
    public string name { get; set; }

    public List<EffectEntry> effect_entries { get; set; } = new();
}