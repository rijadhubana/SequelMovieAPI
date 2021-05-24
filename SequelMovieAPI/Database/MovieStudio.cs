using System;
using System.Collections.Generic;

#nullable disable

namespace SequelMovieAPI.Database
{
    public partial class MovieStudio
    {
        public int MovieStudioId { get; set; }
        public int MMovieId { get; set; }
        public int SStudioId { get; set; }

        public virtual Movie MMovie { get; set; }
        public virtual Studio SStudio { get; set; }
    }
}
