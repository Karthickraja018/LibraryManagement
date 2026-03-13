using LibraryManagement.DTOs;

namespace LibraryManagement.Services.Interfaces
{
    public interface IAuthService
    {
        Task Register(RegisterDTO dto);
        Task<string> Login(LoginDTO dto);
    }
}
