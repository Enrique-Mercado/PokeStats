public class EvolucionPokemon
{
    public string Nombre { get; set; } = "";
    public string Imagen { get; set; } = "";
    public int NumeroPokedex { get; set; }
    public bool EsActual { get; set; }
    public int Profundidad {get;set;}
    public int Nivel { get; set; }
    public int CantidadEvoluciones { get; set; }
    public int Rama { get; set; }
    public bool EsBifurcacion { get; set; }
    public string MetodoEvolucion { get; set; }
    public string Condicion { get; set; }
    public MetodoEvolucion Metodo { get; set; }
    public string ValorMetodo { get; set; }
}