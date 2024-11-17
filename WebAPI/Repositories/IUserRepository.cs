using WebAPI.Models;

namespace WebAPI.Repositories
{
    public interface IUserRepository
    {
        Task<UserModel> GetByIdAsync(int id);
        Task<IEnumerable<UserModel>> GetAllAsync();
        Task<bool> AddAsync(UserModel user);
        Task UpdateAsync(UserModel user);
        Task DeleteAsync(int id);
        Task<UserModel> FindByEmailAsync(string email);

        Task<bool> ExistsByEmailAsync(string email);
    }
}

