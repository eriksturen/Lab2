namespace Lab2;

public class User
{
    // Username and password are private so as to not be changeable from other parts of program
    public string Username { get; set; }
    public string Password { get; set; }

    private string prompt = new Shop().prompt;

    public bool LoggedIn { get; set; }

    public User()
    {
    }

    public User(string userName, string password)
    {
        Username = userName;
        Password = password;
    }


    public void Login()
    {
        List<string> options = new List<string>() { "Logga in", "Registrera ny användare" };
        Menu loginMenu = new Menu(prompt, options);
        int selectedIndex = loginMenu.Run();
        if (selectedIndex == 0)
        {
            // TODO 8 make welcome statements a little prettier?
            Console.WriteLine("Välkommen skriv in användarnamn: ");
            string inputUsername = Console.ReadLine();
            Username = inputUsername;
            Console.WriteLine("Skriv in lösenord: ");
            string inputPassword = Console.ReadLine();
            Password = inputPassword;
            User newUser = new User(inputUsername, inputPassword);
            List<User> users = DataHandler.GetUsers();
            foreach (User user in users)
            {
                if (user.Username == inputUsername && user.Password == inputPassword)
                {
                    LoggedIn = true;
                }
            }
        }
        else if (selectedIndex == 1)
        {
            RegisterUser();
        }
    }

    // Register new User
    public void RegisterUser()
    {
        Console.WriteLine("Välkommen skriv in önskat användarnamn: ");
        string userName = Console.ReadLine();
        Console.WriteLine("Skriv in önskat lösenord: ");
        string password = Console.ReadLine();

        User user = new User(userName, password);
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