namespace Data.Entities;

public class User
{
    public int Id { get; set; }
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
}