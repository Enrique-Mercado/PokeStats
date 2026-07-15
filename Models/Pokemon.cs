public class Pokemon
{
    public int NumeroPokedex { get; set; }
    public string Nombre { get; set; } = "";
    public string Tipo { get; set; } = "";
    public int HP { get; set; }
    public int Ataque { get; set; }
    public int Defensa { get; set; }
    public int AtaqueEspecial { get; set; }
    public int DefensaEspecial { get; set; }
    public int Velocidad { get; set; }
    public string Imagen { get; set; } = "";
    public string Habilidad { get; set; } = "";
    public string ClaseColor { get; set; } = "";
    public string ClaseHeader { get; set; } = "";
    public string ClaseBarra { get; set; } = "";
    public List<string> Tipos { get; set; } = new();
    public string DescripcionHabilidad { get; set; } = "";
    public List<HabilidadPokemon> Habilidades { get; set; } = new();
    public bool is_hidden { get; set; }
    public SpeciesInfo species { get; set; }
    public List<EvolucionPokemon> Evoluciones { get; set; } = new();
    public int Profundidad {get;set;}
    public List<FormaPokemon> Formas { get; set; } = new();
    
}