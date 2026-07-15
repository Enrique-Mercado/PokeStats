using PokeStatsV1.Models;
using System.Net.Http;
using System.Text.Json;
namespace PokeStatsV1.Mappers;


public static class EvolutionMapper
    {
        
    public static List<EvolucionPokemon> Convertir(EvolutionResponse response)
    {
        List<EvolucionPokemon> evoluciones = new();

        RecorrerCadena(
            response.chain,
            evoluciones,
            0,0
        );
           foreach(var evol in evoluciones)
{
    Console.WriteLine(
        $"{evol.Nombre} | {evol.MetodoEvolucion} | {evol.ValorMetodo}"
    );
}

        return evoluciones;
    }
    
    private static void RecorrerCadena(
    Chain chain,
    List<EvolucionPokemon> evoluciones,
    int nivel,
    int rama)
    {
        EvolucionPokemon evo = new();
        if(chain.evolution_details.Any())
        {
            Console.WriteLine($"=== {chain.species.name} ===");

             var detalle = chain.evolution_details.First();

/*Console.WriteLine(JsonSerializer.Serialize(
    detalle,
    new JsonSerializerOptions
    {
        WriteIndented = true
    }));*/
            AsignarMetodoEvolucion(
                evo,
                chain.evolution_details.First()
            );
        }

        evo.Nombre = chain.species.name;
        evo.Nivel = nivel;
        evo.Rama = rama;

        evo.EsBifurcacion =
        chain.evolves_to.Count > 1;
        evoluciones.Add(evo);

        int indiceRama = 0;
        

        foreach(var siguiente in chain.evolves_to)
        {

            RecorrerCadena(
                siguiente,
                evoluciones,
                nivel + 1,
                indiceRama
            );

            indiceRama++;
        }
     
    }
    private static string ObtenerMetodoEvolucion(Chain chain)
    {

        if (!chain.evolution_details.Any())
            return "";

        var detalle = chain.evolution_details.First();

        if (detalle.min_level != null)
            return $"Nivel {detalle.min_level}";

        if (detalle.item != null)
            return detalle.item.name;

        if (detalle.trigger?.name == "trade")
            return "Intercambio";

        if (detalle.min_happiness != null)
            return "Amistad";

        return detalle.trigger?.name ?? "";
    }
    private static void AsignarMetodoEvolucion(
    EvolucionPokemon evolucion,
    EvolutionDetail detalle)
        {


            if (detalle.relative_physical_stats != null)
            {
                evolucion.MetodoEvolucion = "Ataque";

                evolucion.ValorMetodo =
                    detalle.relative_physical_stats switch
                    {
                        1 => "> Defensa",
                        -1 => "< Defensa",
                        0 => "= Defensa",
                        _ => ""
                    };

                return;
            }

            if (detalle.turn_upside_down ?? false)
            {
                evolucion.MetodoEvolucion = "Consola";

                evolucion.ValorMetodo = "Invertida";

                return;
            }

            if (detalle.party_species != null)
            {
                evolucion.MetodoEvolucion = "Equipo";

                evolucion.ValorMetodo =
                    detalle.party_species.name;

                return;
            }

            if (detalle.item != null)
            {
                evolucion.MetodoEvolucion = "Piedra";

                evolucion.ValorMetodo =
                    detalle.item.name;

                return;
            }

            if (detalle.held_item != null)
            {
                evolucion.MetodoEvolucion = "Objeto";

                evolucion.ValorMetodo =
                    detalle.held_item.name;

                return;
            }

            if (detalle.min_beauty != null)
            {
                evolucion.MetodoEvolucion = "Belleza";

                evolucion.ValorMetodo =
                    detalle.min_beauty.ToString();

                return;
            }

            if (detalle.min_happiness != null)
            {
                evolucion.MetodoEvolucion = "Amistad";

                evolucion.ValorMetodo =
                    detalle.min_happiness.ToString();

                return;
            }

            if (detalle.min_level != null)
            {
                evolucion.MetodoEvolucion = "Nivel";

                evolucion.ValorMetodo =
                    detalle.min_level.ToString();

                return;
            }
        }
}
