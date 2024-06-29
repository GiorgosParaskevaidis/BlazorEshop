using BlazorEshop.Shared.DTO;

namespace BlazorEshop.Client.Services.AuthService
{
    public interface IAuthService
    {
        Task<ServiceResponse<int>> Register(UserRegisterDTO request);
        Task<ServiceResponse<string>> Login(UserLoginDTO request);
        Task<ServiceResponse<bool>> ChangePassword(UserChangePasswordDTO request);
        Task<bool> IsUserAuthenticated();
    }
}
