using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SequelMovieAPI.Database;
using SequelMovieAPI.Models;
using SequelMovieAPI.Models.Requests;

namespace SequelMovieAPI.Services
{
    public class ArtisteService : BaseCRUDService<Models.Artiste, ArtisteSearchRequest, Database.Artiste, ArtisteUpsertRequest, ArtisteUpsertRequest>
    {
        public ArtisteService(sequelmovieContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public override List<Models.Artiste> Get(ArtisteSearchRequest search)
        {
            var query = _context.Artistes.AsQueryable();
            if (!string.IsNullOrWhiteSpace(search?.ArtisteName))
            {
                query = query.Where(x => x.ArtisteName.StartsWith(search.ArtisteName));
            }
            var list = query.ToList();
            return _mapper.Map<List<Models.Artiste>>(list);
        }
    }
}
