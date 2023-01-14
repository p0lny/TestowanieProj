using System;

namespace BazaFilmowa.Entities
{
    public class RegistrationToken
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Token { get; set; }
        public DateTime ExpiresAt { get; set; }



        public virtual User User { get; set; }
    }
}