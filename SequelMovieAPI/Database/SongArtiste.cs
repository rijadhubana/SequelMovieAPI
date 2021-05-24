using System;
using System.Collections.Generic;

#nullable disable

namespace SequelMovieAPI.Database
{
    public partial class SongArtiste
    {
        public int SongArtisteId { get; set; }
        public int SSongId { get; set; }
        public int AArtisteId { get; set; }

        public virtual Artiste AArtiste { get; set; }
        public virtual Song SSong { get; set; }
    }
}
