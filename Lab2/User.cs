namespace Lab2;

public class User
{

    // TODO 9 IMPORTANT Username should not be changeable
    public string Username { get; set; }
    public string Password { get; set; }

    public User(string userName, string password)
    {
        Username = userName;
        Password = password;
    }
}