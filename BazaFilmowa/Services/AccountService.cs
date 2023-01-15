using BazaFilmowa.Entities;
using BazaFilmowa.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BazaFilmowa.Services
{
    public class AccountService : IAccountService
    {
        private readonly ApiDbContext _dbContext;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly AuthenticationSettings _authenticationSettings;
        private readonly IEmailService _emailService;

        public AccountService(ApiDbContext dbContext, IPasswordHasher<User> passwordHasher, AuthenticationSettings authenticationSettings, IEmailService emailService )
        {
            _dbContext = dbContext;
            _passwordHasher = passwordHasher;
            _authenticationSettings = authenticationSettings;
            _emailService = emailService;
        }

        public string LoginUser(LoginUserDto loginUserDto)
        {
            if (_dbContext.Users.Any(e => e.Email == loginUserDto.Email))
            {
                var user = _dbContext.Users
                    .Include(e => e.Role)
                    .FirstOrDefault(e => e.Email == loginUserDto.Email);

                var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, loginUserDto.Password);

                if (result == PasswordVerificationResult.Success)
                {

                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Name, $"{user.Name} {user.Surname}"),
                        new Claim(ClaimTypes.Role, $"{user.Role.Name}"),
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
                    var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var expires = DateTime.Now.AddDays(_authenticationSettings.JwtExpireDays);

                    var token = new JwtSecurityToken(
                                    _authenticationSettings.JwtIssuer,
                                    _authenticationSettings.JwtIssuer,
                                    claims,
                                    expires: expires,
                                    signingCredentials: cred);

                    var tokenHandler = new JwtSecurityTokenHandler();

                    return tokenHandler.WriteToken(token);

                }
            }

            throw new Exception();
        }

        public void RegisterUser(RegisterUserDto registerUserDto)
        {
            var user = new User()
            {
                Email = registerUserDto.Email,
                Name = registerUserDto.Name,
                Surname = registerUserDto.Surname,
                RoleId = 3,
                IsActivated = false
            };

            var hashedPassword = _passwordHasher.HashPassword(user, registerUserDto.Password);
            user.PasswordHash = hashedPassword;

            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();

            var guid = new Guid();
            //_dbContext.RegistrationTokens.Add();

            //_emailService.SendVerificationEmail(user.Email);
        }
    }
}
