using BazaFilmowa.Entities;

namespace BazaFilmowa.Services
{
    public interface IJwtTokenProviderService
    {
        public string GetJwtForUser(User user);
    }
}