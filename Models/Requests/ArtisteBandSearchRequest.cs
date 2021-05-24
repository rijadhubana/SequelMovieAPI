using System;
using System.Collections.Generic;
using System.Text;

namespace SequelMovieAPI.Models.Requests
{
    public class ArtisteBandSearchRequest
    {
        public string BandRole { get; set; }
        public int AArtisteId { get; set; }
        public int BBandId { get; set; }
    }
}
