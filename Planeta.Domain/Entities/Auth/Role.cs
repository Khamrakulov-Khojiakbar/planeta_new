namespace Planeta.Domain.Auth;

public class Role
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;
    
    public virtual ICollection<User> Users { get; set; } = new List<User>();
    public virtual ICollection<Permission> Permissions { get; set; } = new List<Permission>();
}