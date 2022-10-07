namespace Lab2;

public class User
{
    // TODO 14 DiscountLevel implementation - apperently this needs to be as inheritance from the User-class
    // so read/write functions and everything needs to be updated.
    // The datafile for Users also needs to contain info on the discount level

    // Username and password are private so as to not be changeable from other parts of program
    public string Username { get; set; }
    public string Password { get; set; }

    private string prompt = Program.prompt;

    public bool LoggedIn { get; set; }


    public User()
    {
        Console.WriteLine("Skriv in användarnamn: ");
        string username = Console.ReadLine();
        Console.WriteLine("Skriv in lösenord: ");
        string password = Console.ReadLine();

        Username = username;
        Password = password;
    }

    public User(string username, string password)
    {
        Username = username;
        Password = password;
    }

    public virtual void Login()
    {
        string[] lines = System.IO.File.ReadAllLines(@"C:\Users\eriks\Documents\Csharp\Lab2\Users.txt");
        List<User> users = new List<User>();
        foreach (string line in lines)
        {
            string[] info = line.Split("; ");
            if (info.Length < 3)
            {
                User newUser = new User(info[0], info[1]);
                users.Add(newUser);
            }
        }
        
        foreach (User u in users)
        {
            if (u.Username == Username && u.Password == Password)
            {
                LoggedIn = true;
                Console.WriteLine("normal user");
                Console.ReadKey();
            }
        }
    }

    // Register new User
    public void RegisterUser()
    {
        User user = new User();
        DataHandler.WriteNewUser(user);
        Console.WriteLine("Användare registrerad. Nu kan du logga in!");
        Console.ReadKey();
        Login();
    }

    // TODO 13 ToString in this way works. It's not very good though so i dunno, maybe ask Niklas about this 
    public override string ToString()
    {
        string username = $"Ditt användarnamn är {Username}";
        string password = $"Ditt lösenord är {Password}";

        return $"################" +
               $"Här är din info:\n" +
               $"{username}\n" +
               $"{password}\n" +
               $"Gå till Kundvagn för att se kundvagn\n" +
               $"################";
    }
}