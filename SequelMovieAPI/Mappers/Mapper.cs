using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SequelMovieAPI.Models.Requests;

namespace SequelMovieAPI.Mappers
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Database.Artiste, Models.Artiste>();
            CreateMap<Database.Artiste, ArtisteUpsertRequest>().ReverseMap();
        }
    }
}
