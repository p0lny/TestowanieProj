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

        public AccountService(ApiDbContext dbContext, IPasswordHasher<User> passwordHasher, AuthenticationSettings authenticationSettings, IEmailService emailService)
        {
            _dbContext = dbContext;
            _passwordHasher = passwordHasher;
            _authenticationSettings = authenticationSettings;
            _emailService = emailService;
        }

        public void ActivateUser(string token)
        {
            if (_dbContext.RegistrationTokens.Any(e => e.Token == token))
            {
                var registrationToken = _dbContext.RegistrationTokens
                                            .Include(e => e.User)
                                            .FirstOrDefault(e => e.Token == token);

                if (DateTime.Now.Subtract(registrationToken.ExpiresAt) > new TimeSpan(0))
                {
                    throw new Exception(); //todo
                }

                registrationToken.User.IsActivated = true;

                _dbContext.SaveChanges();
                _dbContext.RegistrationTokens.Remove(registrationToken);
                _dbContext.SaveChanges();
            }
            else
            {
                throw new Exception(); //todo
            }
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

                    if (!user.IsActivated)
                    {
                        throw new Exception(); //todo
                    }

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

            throw new Exception(); //todo 
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

            var registrationToken = new RegistrationToken()
            {
                UserId = user.Id,
                ExpiresAt = DateTime.Now.AddHours(24),
                Token = Guid.NewGuid().ToString()
            };
            _dbContext.RegistrationTokens.Add(registrationToken);
            _dbContext.SaveChanges();

            _emailService.SendVerificationEmail(user.Email, registrationToken);
        }
    }
}
