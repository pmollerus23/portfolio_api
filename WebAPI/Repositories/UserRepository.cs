using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UserModel> GetByIdAsync(int id)
        {
            return await _context.User.FindAsync(id);
        }

        public async Task<IEnumerable<UserModel>> GetAllAsync()
        {
            return await _context.User.ToListAsync();
        }

        public async Task<bool> AddAsync(UserModel user)
        {
            await _context.User.AddAsync(user);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task UpdateAsync(UserModel user)
        {
            _context.User.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var user = await GetByIdAsync(id);
            if (user != null)
            {
                _context.User.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
        
        public async Task<UserModel?> FindByEmailAsync(string email)
        {
            return await _context.User
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<bool> ExistsByEmailAsync(string email) {
            return await _context.User.AnyAsync(p => p.Email == email);
        }
    }
}

