namespace Planeta.Domain.Auth;

public class User
{
    public int Id { get; set; }

    public string Email { get; set; } = string.Empty;
    public string UserName { get; set; }  = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string HashPassword { get; set; }  = string.Empty;
    public DateTime Created { get; set; } = DateTime.UtcNow;

    public int RoleId { get; set; }
    public virtual Role Role { get; set; } = null!;
}