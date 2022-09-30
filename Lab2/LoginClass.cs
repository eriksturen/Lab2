using System.Threading.Channels;

namespace Lab2;

public class LoginClass
{
    private string prompt = new Shop().prompt;

    public bool LoggedIn { get; set; }

    // Login should take User info 
    // Compare to a user database 
    // if user is found and name + pass matches
    // user becomes logged in 

    // it should also give the possibility to register a user 
    // that shows similar interface and puts an new User in the database 

    

    public void Login()
    {
        List<string> options = new List<string>() { "Logga in", "Registrera ny användare" };
        Menu loginMenu = new Menu(prompt, options);
        int selectedIndex = loginMenu.Run();
        if (selectedIndex == 0)
        {
            // TODO 8 make these a little prettier?
            Console.WriteLine("Välkommen skriv in användarnamn: ");
            string username = Console.ReadLine();
            Console.WriteLine("Skriv in lösenord: ");
            string password = Console.ReadLine();
            User newUser = new User(username, password);
            List<User> users = DataHandler.GetUsers();
            foreach (User user in users)
            {
                if (user.Username == newUser.Username && user.Password == newUser.Password)
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

    // TODO 10 IMPORTANT LogOut function needed
    public void Logout()
    {
        LoggedIn = false;
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
}