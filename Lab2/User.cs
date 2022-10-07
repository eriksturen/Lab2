﻿namespace Lab2;

public class User
{
    
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
        string[] lines = File.ReadAllLines(@"C:\Users\eriks\Documents\Csharp\Lab2\Users.txt");
        List<User> users = new List<User>();
        foreach (string line in lines)
        {
            string[] info = line.Split("; ");
            User newUser = new User(info[0], info[1]);
            users.Add(newUser);
        }
        
        foreach (User u in users)
        {
            if (u.Username == Username && u.Password == Password)
            {
                LoggedIn = true;
            }
        }
    }

    // Register new User
    public void RegisterUser()
    {
        DataHandler.WriteNewUser(this);
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