namespace Planeta.Application.DTOs.Auth;

public record AuthResponse(
    string Token,
    string Username,
    string Role
    );