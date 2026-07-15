namespace PokeStatsV1.Helpers;

public static class PokemonHelpers
{
    public static string ObtenerIcono(string? tipo)
    {
        
        var iconos = new Dictionary<string, string>
        {
            { "fire", "🔥" },
            { "water", "💧" },
            { "grass", "🌿" },
            { "electric", "⚡" },
            { "ice", "❄️" },
            { "rock", "🪨" },
            { "ground", "🌎" },
            { "ghost", "👻" },
            { "dragon", "🐉" },
            { "fairy", "🧚" },
            { "steel", "⚙️" },
            { "psychic", "🔮" },
            { "dark", "🌑" },
            { "bug", "🐛" },
            { "poison", "☠️" },
            { "flying", "🪽" },
            { "normal", "⚪" },
            { "fighting", "🥊" },
            { "", "❔" }
        };

        if (string.IsNullOrWhiteSpace(tipo))
            return "❔";

        tipo = tipo.Trim().ToLower();
        return iconos.TryGetValue(tipo, out var icono)
            ? icono
            : "❔";
    }

    public static string ObtenerDescripcion(AbilityResponse abilityResponse)
    {
        var descripcion =
            abilityResponse.effect_entries
                .FirstOrDefault(s => s.language.name == "es");

        if(descripcion == null)
        {
            descripcion =
                abilityResponse.effect_entries
                    .FirstOrDefault(s => s.language.name == "en");
        }
        return descripcion?.effect ?? "";
    }

    public static string FormatearNombre(string nombre)
    {
        if (string.IsNullOrWhiteSpace(nombre))
            return string.Empty;

        nombre = nombre.Replace("-", " ");
        nombre = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nombre);
        return nombre;
    }
}