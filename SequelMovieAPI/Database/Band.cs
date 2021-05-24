using System;
using System.Collections.Generic;

#nullable disable

namespace SequelMovieAPI.Database
{
    public partial class Band
    {
        public Band()
        {
            ArtisteBands = new HashSet<ArtisteBand>();
            SongBands = new HashSet<SongBand>();
        }

        public int BandId { get; set; }
        public string BandName { get; set; }

        public virtual ICollection<ArtisteBand> ArtisteBands { get; set; }
        public virtual ICollection<SongBand> SongBands { get; set; }
    }
}
