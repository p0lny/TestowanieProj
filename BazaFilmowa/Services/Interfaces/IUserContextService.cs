using System.Security.Claims;

namespace BazaFilmowa.Services
{
    public interface IUserContextService
    {
        public ClaimsPrincipal User { get; }
        public int? GetUserId { get; }
    }
}