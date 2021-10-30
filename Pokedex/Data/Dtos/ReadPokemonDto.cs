using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.Data.Dtos
{
    public class ReadPokemonDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public float Height { get; set; }
        public float Weight { get; set; }
        public string PokemonName { get; set; }
        public string Type { get; set; }
        public DateTime HoraDaConsulta { get; set; }
    }
}
