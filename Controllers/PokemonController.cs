using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PokeStatsV1.Models;
using PokeStatsV1.Services;

namespace PokeStatsV1.Controllers;

public class PokemonController : Controller
{
    public IActionResult Index()
    {

        return View(new Pokemon());
    }

    [HttpPost]
    public async Task<IActionResult> Busqueda(string nombre)
    {
        Console.WriteLine("Entré al Controller");

        //ViewBag.Busca = $"Buscando {nombre}...";
        ViewBag.Busca = "HOLA MARX";

        Pokemon pokemon = await new PokemonService().BuscarPokemon(nombre);

        return View("Index", pokemon);
    }
}