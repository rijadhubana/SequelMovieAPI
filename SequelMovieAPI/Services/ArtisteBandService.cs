using AutoMapper;
using SequelMovieAPI.Database;
using SequelMovieAPI.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SequelMovieAPI.Services
{
    public class ArtisteBandService : BaseCRUDService<Models.ArtisteBand, ArtisteBandSearchRequest, Database.ArtisteBand, ArtisteBandUpsertRequest, ArtisteBandUpsertRequest>
    {
        public ArtisteBandService(sequelmovieContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
