using System;
using System.Collections.Generic;

#nullable disable

namespace SequelMovieAPI.Database
{
    public partial class SongBand
    {
        public int SongBandId { get; set; }
        public int SongSongId { get; set; }
        public int BBandId { get; set; }

        public virtual Band BBand { get; set; }
        public virtual Song SongSong { get; set; }
    }
}
