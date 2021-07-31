﻿using System;
using System.Collections.Generic;


namespace MPGC_API.Models
{
    public partial class Genre
    {
        public Genre()
        {
            Games = new HashSet<Game>();
        }

        public int Idgenre { get; set; }
        public string NameGenre { get; set; }
        public string GenreColor { get; set; }

        public virtual ICollection<Game> Games { get; set; }
    }
}
