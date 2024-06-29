
using System.Net.Http.Json;
using BlazorEshop.Shared.DTO;

namespace BlazorEshop.Client.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _http;
        private readonly AuthenticationStateProvider _authStateProvider;

        public AuthService(HttpClient http, AuthenticationStateProvider authStateProvider)
        {
            _http = http;
            _authStateProvider = authStateProvider;
        }

        public async Task<ServiceResponseDTO<bool>> ChangePassword(UserChangePasswordDTO request)
        {
            var result = await _http.PostAsJsonAsync("api/auth/change-password", request.Password);
            return await result.Content.ReadFromJsonAsync<ServiceResponseDTO<bool>>();
        }

        public async Task<bool> IsUserAuthenticated()
        {
            return (await _authStateProvider.GetAuthenticationStateAsync()).User.Identity!.IsAuthenticated;
        }

        public async Task<ServiceResponseDTO<string>> Login(UserLoginDTO request)
        {
            var result = await _http.PostAsJsonAsync("api/auth/login", request);
            return await result.Content.ReadFromJsonAsync<ServiceResponseDTO<string>>();
        }

        public async Task<ServiceResponseDTO<int>> Register(UserRegisterDTO request)
        {
            var result = await _http.PostAsJsonAsync("api/auth/register", request);
            return await result.Content.ReadFromJsonAsync<ServiceResponseDTO<int>>();
        }
    }
}
