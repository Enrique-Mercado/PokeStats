public class FormaPokemon
{
    public string Nombre { get; set; } = "";

    public string NombreMostrar { get; set; } = "";

    public string Imagen { get; set; } = "";

    public int NumeroPokedex { get; set; }

    public bool EsActual { get; set; }

    public bool EsDefault { get; set; }

    public TipoForma Tipo { get; set; }
}