using System;
using System.Collections.Generic;
using System.Text;

namespace SequelMovieAPI.Models.Requests
{
    public class ArtisteBandUpsertRequest
    {
        public int ArtisteBandId { get; set; }
        public string BandRole { get; set; }
        public int AArtisteId { get; set; }
        public int BBandId { get; set; }
    }
}
