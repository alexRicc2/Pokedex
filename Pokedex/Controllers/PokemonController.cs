using Microsoft.AspNetCore.Mvc;
using Pokedex.Data;
using Pokedex.Models;
using System.Collections.Generic;
using System.Linq;


namespace Pokedex.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonController : ControllerBase
    {

        private PokemonContext _context;

        public PokemonController(PokemonContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult AdicionaPokemon([FromBody] Pokemon pokemon)
        {
            _context.Pokemons.Add(pokemon);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RetornaPokemonPorId), new { Id = pokemon.Id }, pokemon);
        }


        [HttpGet]
        public IActionResult RetornaPokedex()
        {
            return Ok(_context.Pokemons);
        }

        [HttpGet("{id}")]
        public IActionResult RetornaPokemonPorId(int id)
        {
            Pokemon pokemon = _context.Pokemons.FirstOrDefault(pokemon => pokemon.Id == id);
            if (pokemon != null) return Ok(pokemon);
            return NotFound();
        }
    }
}
