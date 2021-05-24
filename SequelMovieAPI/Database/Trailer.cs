using System;
using System.Collections.Generic;

#nullable disable

namespace SequelMovieAPI.Database
{
    public partial class Trailer
    {
        public int TrailerId { get; set; }
        public int? TrailerLength { get; set; }
        public string TrailerUrl { get; set; }
        public int TMovieId { get; set; }

        public virtual Movie TMovie { get; set; }
    }
}
