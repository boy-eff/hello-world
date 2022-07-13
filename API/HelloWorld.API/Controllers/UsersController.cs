using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorld.Infrastructure.Data;
using HelloWorld.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using HelloWorld.Infrastructure.Interfaces;
using HelloWorld.API.Interfaces;
using HelloWorld.Shared.DTO;

namespace HelloWorld.API.Controllers
{
    [Authorize]
    public class UsersController : BaseApiController
    {
        private readonly IUserService _userService;
        private readonly IPhotoService _photoService;
        public UsersController(IUserService userService, IPhotoService photoService)
        {
            _photoService = photoService;
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserInfoDto>>> GetUsers()
        {
            var users = await _userService.GetUsersAsync();
            if (users.Count() > 0)
            {
                return Ok(users);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpGet("{username}")]
        public async Task<ActionResult<UserInfoDto>> GetUserByUsername(string username)
        {
            var user = await _userService.GetUserByUsernameAsync(username);
            if (user != null)
            {
                return Ok(user);
            }
            else 
            {
                return NoContent();
            }
        }

        [HttpPost("photo")]
        public async Task<ActionResult> AddPhoto(IFormFile file)
        {
            await _userService.AddPhoto(file);
            return Ok();
        }
    }
}