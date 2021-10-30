using AutoMapper;
using Pokedex.Data.Dtos;
using Pokedex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.Profiles
{
    public class PokemonProfile : Profile
    {
        public PokemonProfile()
        {
            CreateMap<CreatePokemonDto, Pokemon>();
            CreateMap<Pokemon, ReadPokemonDto>();
            CreateMap<UpdatePokemonDto, Pokemon>();
        }
    }
}
