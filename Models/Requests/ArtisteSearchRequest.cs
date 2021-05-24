using System;
using System.Collections.Generic;
using System.Text;

namespace SequelMovieAPI.Models.Requests
{
    public class ArtisteSearchRequest
    {
        public string ArtisteName { get; set; }
        public string ArtisteNationality { get; set; }
    }
}
