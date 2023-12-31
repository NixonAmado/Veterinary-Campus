namespace Domain.Entities;

public class User : BaseEntity
{
    public string Name {get;set;}
    public string Email {get;set;}
    public string Password {get;set;}
    public ICollection<Role> Roles {get;set;} = new HashSet<Role>();
    public ICollection<UserRole> UsersRoles {get;set;}
    public ICollection<RefreshToken> RefreshTokens { get; set; } = new HashSet<RefreshToken>();

}   
