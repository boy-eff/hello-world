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
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            var users = await _userService.GetUsersAsync();
            return Ok(users);
        }

        [HttpPost("photo")]
        public async Task<ActionResult> AddPhoto(IFormFile file)
        {
            await _userService.AddPhoto(file);
            return Ok();
        }
    }
}