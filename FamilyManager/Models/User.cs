using SQLite;

namespace FamilyManager.Models;

public enum UserRole
{
    Admin,
    User
}

[Table("Users")]
public class User
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    [Unique]
    public string Email { get; set; }

    public string FullName { get; set; }

    public string PhoneNumber { get; set; }

    public string Username { get; set; }

    public string Password { get; set; }

    public string Avatar { get; set; }

    public UserRole Role { get; set; }
}
