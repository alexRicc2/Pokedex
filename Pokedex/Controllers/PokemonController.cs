using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pokedex.Data;
using Pokedex.Data.Dtos;
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
        private IMapper _mapper;

        public PokemonController(PokemonContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        [HttpPost]
        public IActionResult AdicionaPokemon([FromBody] CreatePokemonDto pokemonDto)
        {
            Pokemon pokemon = _mapper.Map<Pokemon>(pokemonDto);
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
            if (pokemon != null) {
                ReadPokemonDto pokemonDto = _mapper.Map<ReadPokemonDto>(pokemon);
                return Ok(pokemonDto); }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaPokemon(int id, [FromBody] UpdatePokemonDto pokemonDtoNovo)
        {
            Pokemon pokemon = _context.Pokemons.FirstOrDefault(pokemon => pokemon.Id == id);
            if(pokemon == null)
            {
                return NotFound();
            }
            _mapper.Map(pokemonDtoNovo, pokemon);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaPokemon(int id)
        {
            Pokemon pokemon = _context.Pokemons.FirstOrDefault(pokemon => pokemon.Id == id);
            if(pokemon == null)
            {
                return NotFound();
            }

            _context.Remove(pokemon);
            _context.SaveChanges();
            return NoContent();
        }
    }
}