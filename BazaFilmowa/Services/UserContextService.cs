using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BazaFilmowa.Services
{
    public class UserContextService :IUserContextService
    {
        private readonly IHttpContextAccessor _httpContextAccesor;
        public UserContextService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccesor = httpContextAccessor;
        }

        public ClaimsPrincipal User => _httpContextAccesor.HttpContext?.User;
        public int? GetUserId => User is null ? null : (int?) int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value);
    }
}
