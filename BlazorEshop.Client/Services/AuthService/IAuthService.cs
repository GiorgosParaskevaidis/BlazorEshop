using BlazorEshop.Shared.DTO;

namespace BlazorEshop.Client.Services.AuthService
{
    public interface IAuthService
    {
        Task<ServiceResponseDTO<int>> Register(UserRegisterDTO request);
        Task<ServiceResponseDTO<string>> Login(UserLoginDTO request);
        Task<ServiceResponseDTO<bool>> ChangePassword(UserChangePasswordDTO request);
        Task<bool> IsUserAuthenticated();
    }
}
