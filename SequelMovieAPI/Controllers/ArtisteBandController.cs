using SequelMovieAPI.Models;
using SequelMovieAPI.Models.Requests;
using SequelMovieAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SequelMovieAPI.Controllers
{
    public class ArtisteBandController : BaseCRUDController<Models.ArtisteBand, ArtisteBandSearchRequest, ArtisteBandUpsertRequest, ArtisteBandUpsertRequest>
    {
        public ArtisteBandController(ICRUDService<ArtisteBand, ArtisteBandSearchRequest, ArtisteBandUpsertRequest, ArtisteBandUpsertRequest> service) : base(service)
        {
        }
    }
}
