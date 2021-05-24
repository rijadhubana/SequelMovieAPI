using System;
using System.Collections.Generic;

#nullable disable

namespace SequelMovieAPI.Database
{
    public partial class Role
    {
        public int RoleId { get; set; }
        public string RoleDesc { get; set; }
        public int MMovieId { get; set; }
        public int PPersonId { get; set; }

        public virtual Movie MMovie { get; set; }
        public virtual Person PPerson { get; set; }
    }
}
