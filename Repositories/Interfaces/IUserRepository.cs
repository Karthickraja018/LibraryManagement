using LibraryManagement.Models;
namespace LibraryManagement.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetByIdAsync(int id);
        Task AddAsync(User user);
        Task<User> GetByEmailAsync(string email);
    }
}
