using HelloWorld.Infrastructure.Data;
using HelloWorld.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using HelloWorld.Application.Interfaces;

namespace HelloWorld.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<AppUser> GetUserByUsername(string username)
        {
             return await _context.Users
                .Include(u => u.Photo)
                .SingleOrDefaultAsync(x => x.UserName == username.ToLower());
        }

        public async Task<IEnumerable<AppUser>> GetUsersAsync()
        {
            return await _context.Users
                .Include(u => u.Photo)
                .ToListAsync();
        }

        public async Task AddPhoto(AppUser user, Photo photo)
        {
            user.Photo = photo;
            await _context.SaveChangesAsync();
        }
    }
}