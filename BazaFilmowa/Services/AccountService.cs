using BazaFilmowa.Entities;
using BazaFilmowa.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BazaFilmowa.Services
{
    public class AccountService : IAccountService
    {
        private readonly ApiDbContext _dbContext;
        private readonly IPasswordHasher<User> _passwordHasher;

        public AccountService(ApiDbContext dbContext, IPasswordHasher<User> passwordHasher)
        {
            _dbContext = dbContext;
            _passwordHasher = passwordHasher;
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
        }
    }
}
