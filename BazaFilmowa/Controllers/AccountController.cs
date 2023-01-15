using BazaFilmowa.Models;
using BazaFilmowa.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BazaFilmowa.Controllers
{
    [Route("api/account")]
    [ApiController]
    [AllowAnonymous]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("login")]
        [SwaggerResponse(200)]
        [SwaggerResponse(401)]
        public ActionResult Login([FromBody] LoginUserDto loginUserDto)
        {
            var token = _accountService.LoginUser(loginUserDto);
            return Ok(token);
        }


        [HttpPost("register")]
        [SwaggerResponse(201)]
        [SwaggerResponse(400)]
        public ActionResult Register([FromBody] RegisterUserDto registerUserDto)
        {
            _accountService.RegisterUser(registerUserDto);
            return Ok();
        }

        [HttpPost("activate/{token}")]
        [SwaggerResponse(200)]
        [SwaggerResponse(404)]
        public ActionResult Activate([FromRoute] string token)
        {
            _accountService.ActivateUser(token);
            return Ok();
        }
    }
}
