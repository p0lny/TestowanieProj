﻿using System;

namespace BazaFilmowa.Models

{
    public class RegisterUserDto
    {
        public string Name{ get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirmation { get; set; }

    }
}