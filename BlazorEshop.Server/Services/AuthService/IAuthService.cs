using BlazorEshop.Shared.DTO;

namespace BlazorEshop.Server.Services.AuthService
{
    public interface IAuthService
    {
        Task<ServiceResponseDTO<int>> Register(User user, string password);
        Task<bool> UserExists(string email);
        Task<ServiceResponseDTO<string>> Login(string email, string password);
        Task<ServiceResponseDTO<bool>> ChangePassword(int userId, string newPassword);
        int GetUserId();
        string GetUserEmail();

        Task<User> GetUserByEmail(string email);
    }
}
