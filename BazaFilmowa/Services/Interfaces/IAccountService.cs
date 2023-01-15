using BazaFilmowa.Models;

namespace BazaFilmowa.Services
{
    public interface IAccountService
    {
        void RegisterUser(RegisterUserDto registerUserDto);
        string LoginUser(LoginUserDto loginUserDto);
        void ActivateUser(string token);
    }
}