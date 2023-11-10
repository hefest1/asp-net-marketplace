namespace Data.Entities;

public sealed class User : Entity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public User()
    {
        FirstName = String.Empty;
        LastName = String.Empty;
        Email = String.Empty;
        Password = String.Empty;
    }

    public static User Create(DTOs.UserDTO dataSource)
    {
        return new User()
        {
            FirstName = dataSource.FirstName,
            LastName = dataSource.LastName,
            Email = dataSource.Email,
            Password = dataSource.Password,
        };
    }
}