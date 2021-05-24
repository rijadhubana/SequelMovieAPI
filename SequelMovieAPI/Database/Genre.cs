using System;
using System.Collections.Generic;

#nullable disable

namespace SequelMovieAPI.Database
{
    public partial class Genre
    {
        public Genre()
        {
            MovieGenres = new HashSet<MovieGenre>();
        }

        public int GenreId { get; set; }
        public string GenreType { get; set; }
        public string GenreDesc { get; set; }

        public virtual ICollection<MovieGenre> MovieGenres { get; set; }
    }
}
