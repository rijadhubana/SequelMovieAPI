using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SequelMovieAPI.Models.Requests
{
    public class ArtisteUpsertRequest
    {
        [Required]
        public int ArtisteId { get; set; }
        [Required]
        public string ArtisteName { get; set; }
        public string ArtisteNationality { get; set; }
    }
}
