using System;
using System.Collections.Generic;

#nullable disable

namespace SequelMovieAPI.Database
{
    public partial class MovieGenre
    {
        public int MovieGenreId { get; set; }
        public int MMovieId { get; set; }
        public int GGenreId { get; set; }

        public virtual Genre GGenre { get; set; }
        public virtual Movie MMovie { get; set; }
    }
}
