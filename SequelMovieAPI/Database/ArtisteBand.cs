using System;
using System.Collections.Generic;

#nullable disable

namespace SequelMovieAPI.Database
{
    public partial class ArtisteBand
    {
        public int ArtisteBandId { get; set; }
        public string BandRole { get; set; }
        public int AArtisteId { get; set; }
        public int BBandId { get; set; }

        public virtual Artiste AArtiste { get; set; }
        public virtual Band BBand { get; set; }
    }
}
