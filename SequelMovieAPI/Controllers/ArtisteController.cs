using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SequelMovieAPI.Models;
using SequelMovieAPI.Models.Requests;
using SequelMovieAPI.Services;

namespace SequelMovieAPI.Controllers
{
    public class ArtisteController : BaseCRUDController<Models.Artiste, ArtisteSearchRequest, ArtisteUpsertRequest, ArtisteUpsertRequest>
    {
        public ArtisteController(ICRUDService<Artiste, ArtisteSearchRequest, ArtisteUpsertRequest, ArtisteUpsertRequest> service) : base(service)
        {
        }
    }
}
