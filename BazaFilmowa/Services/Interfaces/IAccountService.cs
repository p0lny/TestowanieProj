﻿using BazaFilmowa.Models;

namespace BazaFilmowa.Services
{
    public interface IAccountService
    {
        void RegisterUser(RegisterUserDto registerUserDto);
    }
}