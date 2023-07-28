using Api.Models.Domains;
using Api.Models.DTOs;

namespace Api.Repositories.Users
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();

        Task<User?> GetByIdAsync(Guid id);

        Task<User?> CreateUserAsync(User user);

        Task<User?> UpdateUserAsync(Guid id, UpdateUserDto userDto);

        Task<User?> DeleteUserAsync(Guid id);
        
    }
}
