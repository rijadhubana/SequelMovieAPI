using System;
using System.Collections.Generic;

#nullable disable

namespace SequelMovieAPI.Database
{
    public partial class Movie
    {
        public Movie()
        {
            MovieGenres = new HashSet<MovieGenre>();
            MovieStudios = new HashSet<MovieStudio>();
            Posters = new HashSet<Poster>();
            Roles = new HashSet<Role>();
            Soundtracks = new HashSet<Soundtrack>();
            Trailers = new HashSet<Trailer>();
        }

        public int MovieId { get; set; }
        public string MovieTitle { get; set; }
        public string MovieDesc { get; set; }
        public DateTime? MovieReleaseDate { get; set; }
        public int? MovieRuntime { get; set; }
        public string MovieCertificate { get; set; }
        public int? MovieRating { get; set; }

        public virtual ICollection<MovieGenre> MovieGenres { get; set; }
        public virtual ICollection<MovieStudio> MovieStudios { get; set; }
        public virtual ICollection<Poster> Posters { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
        public virtual ICollection<Soundtrack> Soundtracks { get; set; }
        public virtual ICollection<Trailer> Trailers { get; set; }
    }
}
