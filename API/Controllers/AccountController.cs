using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTO;
using API.Interfaces;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;
        public AccountController(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterDto registerDto)
        {
            if (await _userService.UserExistsAsync(registerDto.UserName)) return BadRequest("Username is taken");
            
            var user = _userService.GetUserFromRegisterDto(registerDto);

            var result = await _userService.CreateUserAsync(user, registerDto.Password);

            if (!result.Succeeded) return BadRequest(result.Errors);

            return Ok();
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _userService.GetUserByUsername(loginDto.UserName);
            if (user == null)
            {
                return Unauthorized("Invalid username");
            }

            var result = await _userService.CheckPasswordAsync(user, loginDto.Password);

            if (!result.Succeeded) return Unauthorized();
            var resultUser = new UserDto
            {
                UserName = user.UserName,
                Token = await _tokenService.CreateToken(user)
            };
            return Ok(resultUser);
        }
    }
}