using BazaFilmowa.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BazaFilmowa.IntegrationTests
{
    public static class FakeUserProvider
    {

        public static User GeUserForRole(string role)
        {
            switch (role)
            {
                case "Admin":
                    return GetTestAdmin();
                case "Moderator":
                    return GetTestModerator();
                case "User":
                    return GetTestUser();
            }

            return null;
        }
        private static User GetTestUser()
        {

            var user = new User()
            {
                Name = "TestUser",
                Role = new Role()
                {
                    Name = "User"
                },
            };

            return user;

        }

        private static User GetTestModerator()
        {

            var user = new User()
            {
                Name = "TestModerator",
                Role = new Role()
                {
                    Name = "Moderator"
                },
            };

            return user;
        }

        private static User GetTestAdmin()
        {

            var user = new User()
            {
                Name = "TestAdmin",
                Role = new Role()
                {
                    Name = "Admin"
                },
            };

            return user;

        }
    }
}
