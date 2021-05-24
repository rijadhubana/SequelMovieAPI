using System;
using System.Collections.Generic;

#nullable disable

namespace SequelMovieAPI.Database
{
    public partial class Song
    {
        public Song()
        {
            SongArtistes = new HashSet<SongArtiste>();
            SongBands = new HashSet<SongBand>();
            SoundtrackSongs = new HashSet<SoundtrackSong>();
        }

        public int SongId { get; set; }
        public string SongName { get; set; }
        public int? SongLength { get; set; }
        public string SongUrl { get; set; }

        public virtual ICollection<SongArtiste> SongArtistes { get; set; }
        public virtual ICollection<SongBand> SongBands { get; set; }
        public virtual ICollection<SoundtrackSong> SoundtrackSongs { get; set; }
    }
}
