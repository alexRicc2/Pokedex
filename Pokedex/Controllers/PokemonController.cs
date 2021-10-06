using Microsoft.AspNetCore.Mvc;
using Pokedex.Models;
using System.Collections.Generic;
using System.Linq;


namespace Pokedex.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonController : ControllerBase
    {
        private static List<Pokemon> pokedex = new List<Pokemon>();
        private static int id = 1;

        [HttpPost]
        public IActionResult AdicionaPokemon([FromBody] Pokemon pokemon)
        {
            pokemon.Id = id++;
            pokedex.Add(pokemon);
            return CreatedAtAction(nameof(RetornaPokemonPorId), new { Id = pokemon.Id }, pokemon);
        }


        [HttpGet]
        public IActionResult RetornaPokedex()
        {
            return Ok(pokedex);
        }

        [HttpGet("{id}")]
        public IActionResult RetornaPokemonPorId(int id)
        {
            Pokemon pokemon = pokedex.FirstOrDefault(pokemon => pokemon.Id == id);
            if (pokemon != null) return Ok(pokemon);
            return NotFound();
        }
    }
}
