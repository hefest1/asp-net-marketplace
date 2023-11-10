namespace Data.DTOs;

public sealed class UserDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public UserDTO()
    {
        FirstName = String.Empty;
        LastName = String.Empty;
        Email = String.Empty;
        Password = String.Empty;
    }
}