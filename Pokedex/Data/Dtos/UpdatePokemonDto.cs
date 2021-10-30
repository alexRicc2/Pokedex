using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.Data.Dtos
{
    public class UpdatePokemonDto
    {
        public float Height { get; set; }
        public float Weight { get; set; }
        public string PokemonName { get; set; }
        public string Type { get; set; }
    }
}
