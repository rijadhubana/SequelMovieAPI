using System;
using System.Collections.Generic;

#nullable disable

namespace SequelMovieAPI.Database
{
    public partial class SoundtrackSong
    {
        public int SoundtrackSongId { get; set; }
        public int SoundtrackSoundtrackId { get; set; }
        public int SongSongId { get; set; }

        public virtual Song SongSong { get; set; }
        public virtual Soundtrack SoundtrackSoundtrack { get; set; }
    }
}
