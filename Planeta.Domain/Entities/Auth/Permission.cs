namespace Planeta.Domain.Auth;

public class Permission
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
}