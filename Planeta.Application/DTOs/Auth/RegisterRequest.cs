namespace Planeta.Application.DTOs.Auth;

public record RegisterRequest(
    string Email,
    string UserName,
    string Password,
    string PhoneNumber);