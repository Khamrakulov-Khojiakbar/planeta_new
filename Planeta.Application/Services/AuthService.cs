using Planeta.Application.DTOs.Auth;
using Planeta.Application.Interfaces;

namespace Planeta.Application.Services;

public class AuthService : IAuthService
{
    
    
    public Task<AuthResponse> RegisterAsync(RegisterRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<AuthResponse> LoginAsync(LoginRequest request)
    {
        throw new NotImplementedException();
    }
}