using BazaFilmowa.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BazaFilmowa
{
    public class ApiDbSeeder
    {

        private readonly ApiDbContext _dbContext;
        private readonly IPasswordHasher<User> _passwordHasher;
        public ApiDbSeeder(ApiDbContext dbContext, IPasswordHasher<User> passwordHasher)
        {
            _dbContext = dbContext;
            _passwordHasher = passwordHasher;
        }

        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Roles.Any())
                {
                    var roles = GetRoles();
                    _dbContext.Roles.AddRange(roles);
                    _dbContext.SaveChanges();
                }

                if (!_dbContext.Users.Any())
                {
                    var users = GetUsers();
                    _dbContext.Users.AddRange(users);
                    _dbContext.SaveChanges();
                }

                if (!_dbContext.Movies.Any())
                {
                    var movies = GetMovies();
                    _dbContext.Movies.AddRange(movies);
                    _dbContext.SaveChanges();
                }

            }
        }


        private IEnumerable<Movie> GetMovies()
        {
            var movies = new List<Movie>()
            {
                new Movie()
                {
                    Title =" film 1",
                },
                      new Movie()
                {
                    Title =" film 2",
                },
                            new Movie()
                {
                    Title =" film 3",
                },
                                  new Movie()
                {
                    Title =" film 4",
                },
                                        new Movie()
                {
                    Title =" film 5",
                },
            };

            return movies;
        }

        private IEnumerable<Role> GetRoles()
        {
            var roles = new List<Role>()
            {
                new Role()
                {
                   Name = "Admin",
                   Description = String.Empty
                },
                                new Role()
                {
                   Name = "Moderator",
                   Description = String.Empty
                },
                                                new Role()
                {
                   Name = "User",
                   Description = String.Empty
                }
            };

            return roles;
        }

        private IEnumerable<User> GetUsers()
        {
            var users = new List<User>()
            {

            };

            var admin = new User()
            {
                Name = "admin",
                Surname = null,
                Email = "admin@test.com",
                IsActivated = true,
                RoleId = 1
            };

            var adminHashedPassword = _passwordHasher.HashPassword(admin, "admin");
            admin.PasswordHash = adminHashedPassword;

            users.Add(admin);

            return users;
        }
    }
}
