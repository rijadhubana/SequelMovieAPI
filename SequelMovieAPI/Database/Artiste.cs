using System;
using System.Collections.Generic;

#nullable disable

namespace SequelMovieAPI.Database
{
    public partial class Artiste
    {
        public Artiste()
        {
            ArtisteBands = new HashSet<ArtisteBand>();
            SongArtistes = new HashSet<SongArtiste>();
        }

        public int ArtisteId { get; set; }
        public string ArtisteName { get; set; }
        public string ArtisteNationality { get; set; }

        public virtual ICollection<ArtisteBand> ArtisteBands { get; set; }
        public virtual ICollection<SongArtiste> SongArtistes { get; set; }
    }
}
