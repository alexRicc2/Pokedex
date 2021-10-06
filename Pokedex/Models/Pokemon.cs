using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.Models
{
    public class Pokemon
    {
        public int Id { get; set; }
        [Required]
        public string PokemonName { get; set; }
        public float Height { get; set; }
        public float Weight { get; set; }

        public string Type { get; set; }

    }
}
