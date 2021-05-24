using System;
using System.Collections.Generic;

#nullable disable

namespace SequelMovieAPI.Database
{
    public partial class Soundtrack
    {
        public Soundtrack()
        {
            SoundtrackSongs = new HashSet<SoundtrackSong>();
        }

        public int SoundtrackId { get; set; }
        public string SoundtrackName { get; set; }
        public int? SoundtrackSize { get; set; }
        public int MMovieId { get; set; }

        public virtual Movie MMovie { get; set; }
        public virtual ICollection<SoundtrackSong> SoundtrackSongs { get; set; }
    }
}
