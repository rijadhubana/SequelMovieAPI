using System;
using System.Collections.Generic;

#nullable disable

namespace SequelMovieAPI.Database
{
    public partial class Studio
    {
        public Studio()
        {
            MovieStudios = new HashSet<MovieStudio>();
        }

        public int StudioId { get; set; }
        public string StudioName { get; set; }
        public string StudioAddress { get; set; }

        public virtual ICollection<MovieStudio> MovieStudios { get; set; }
    }
}
