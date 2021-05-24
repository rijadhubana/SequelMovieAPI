using System;
using System.Collections.Generic;

#nullable disable

namespace SequelMovieAPI.Database
{
    public partial class Person
    {
        public Person()
        {
            Roles = new HashSet<Role>();
        }

        public int PersonId { get; set; }
        public string PersonFirstName { get; set; }
        public string PersonLastName { get; set; }
        public string PersonNationality { get; set; }
        public string PersonPicture { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}
