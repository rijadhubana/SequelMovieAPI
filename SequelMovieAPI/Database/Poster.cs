using System;
using System.Collections.Generic;

#nullable disable

namespace SequelMovieAPI.Database
{
    public partial class Poster
    {
        public int PosterId { get; set; }
        public string PosterLink { get; set; }
        public int PMovieId { get; set; }

        public virtual Movie PMovie { get; set; }
    }
}
