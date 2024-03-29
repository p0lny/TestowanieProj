﻿

using System.Collections.Generic;

namespace BazaFilmowa.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public bool IsActivated { get; set; }
        public int RoleId { get; set; }


        public virtual UserMovieRating UserMovieRating { get; set; }
        public virtual IEnumerable<MovieToBeWatched> MoviesToBeWatched { get; set; }
        public virtual IEnumerable<MovieWatched> MoviesWatched { get; set; }
        public virtual IEnumerable<Comment> Comments { get; set; }
        public virtual Role Role { get; set; }
        public virtual RegistrationToken RegistrationToken { get; set; }
    }
}
