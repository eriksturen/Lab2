namespace Lab2;

public class LoginClass
{
    private string prompt = new Shop().prompt;   
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
            Console.WriteLine("Ok välkommen skriv in användarnamn: ");
            string userName = Console.ReadLine();
            Console.WriteLine("Skriv in lösenord: ");
            string password = Console.ReadLine();
        }
        Console.ReadKey();
    }

    // Register new User
    // public User RegisterUser()
    // {
    //
    // }
}