using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PokeStatsV1.Models;
using PokeStatsV1.Services;

namespace PokeStatsV1.Controllers;

public class PokemonController : Controller
{
    public async Task<IActionResult> Index()
{
    PokemonListService listaService = new PokemonListService();

    PokemonViewModel modelo = new();

    modelo.Pokemon = new Pokemon();

    modelo.ListaPokemon = await listaService.ObtenerListaPokemon();

    return View("Index", modelo);
}

    [HttpPost]
    public async Task<IActionResult> Busqueda(string busqueda)
    {
        //Console.WriteLine("Entré al Controller");

        ViewBag.Busca = $"Buscando a: {busqueda}...";
        //ViewBag.Busca = "HOLA MARX";
        Pokemon pokemon = await new PokemonService().BuscarPokemon(busqueda);

        PokemonListService listaService = new PokemonListService();

        PokemonViewModel modelo = new();

        modelo.Pokemon = pokemon;

        modelo.ListaPokemon = await listaService.ObtenerListaPokemon();

        return View("Index", modelo);
    }
}