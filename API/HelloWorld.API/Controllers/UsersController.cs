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
using HelloWorld.API.DTO;

namespace HelloWorld.API.Controllers
{
    [Authorize]
    public class UsersController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly IUserService _userService;
        private readonly IPhotoService _photoService;
        public UsersController(DataContext context, IUserService userService, IPhotoService photoService)
        {
            _photoService = photoService;
            _userService = userService;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserInfoDto>>> GetUsers()
        {
            var users = await _userService.GetUsersAsync();
            return Ok(users);
        }

        [HttpGet("{username}")]
        public async Task<ActionResult<UserInfoDto>> GetUserByUsername(string username)
        {
            var user = await _userService.GetUserByUsernameAsync(username);
            return Ok(user);
        }

        [HttpPost("photo")]
        public async Task<ActionResult> AddPhoto(IFormFile file)
        {
            await _userService.AddPhoto(file);
            return Ok();
        }
    }
}