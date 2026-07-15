public class FormaHelpers
{
    public static void Clasificar(FormaPokemon forma)
    {
        string nombre = forma.Nombre.ToLower();

        if (forma.EsDefault)
        {
            forma.Tipo = TipoForma.Default;
            forma.NombreMostrar = "Base";
            return;
        }

        if (nombre.Contains("-mega"))
        {
            forma.Tipo = TipoForma.Mega;

            forma.NombreMostrar =
                ObtenerMega(nombre);

            return;
        }

        if (nombre.Contains("-gmax"))
        {
            forma.Tipo = TipoForma.Gigamax;

            forma.NombreMostrar = "Gigamax";

            return;
        }

        if (nombre.Contains("-alola"))
        {
            forma.Tipo = TipoForma.Regional;

            forma.NombreMostrar = "Alola";

            return;
        }

        if (nombre.Contains("-galar"))
        {
            forma.Tipo = TipoForma.Regional;

            forma.NombreMostrar = "Galar";

            return;
        }

        if (nombre.Contains("-hisui"))
        {
            forma.Tipo = TipoForma.Regional;

            forma.NombreMostrar = "Hisui";

            return;
        }

        if (nombre.Contains("-paldea"))
        {
            forma.Tipo = TipoForma.Regional;

            forma.NombreMostrar = "Paldea";

            return;
        }

        forma.Tipo = TipoForma.Otra;

        forma.NombreMostrar = forma.Nombre;
    }

    private static string ObtenerMega(string nombre)
    {
        if (nombre.EndsWith("-mega-x"))
            return "Mega X";

        if (nombre.EndsWith("-mega-y"))
            return "Mega Y";
        if (nombre.EndsWith("-mega-z"))
            return "Mega Z";

        return "Mega";
    }
}
