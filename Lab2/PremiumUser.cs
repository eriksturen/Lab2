namespace Lab2;

public class PremiumUser : User
{
    public string? DiscountName { get; set; }
    private double _discountLevel;

    public double DiscountLevel
    {
        get { return _discountLevel; }
        set
        {
            switch (DiscountName)
            {
                case "Gold":
                    _discountLevel = 0.15;
                    break;
                case "Silver":
                    _discountLevel = 0.10;
                    break;
                case "Bronze":
                    _discountLevel = 0.05;
                    break;
            }
        }
    }


    public PremiumUser(string username, string password, string discountName)
    {
        Username = username;
        Password = password;
        DiscountName = discountName;
    }

    public PremiumUser()
    {
    }

    public override void Login()
    {
        string[] lines = File.ReadAllLines(@"C:\Users\eriks\Documents\Csharp\Lab2\Users.txt");
        List<PremiumUser> users = new List<PremiumUser>();
        foreach (string line in lines)
        {
            string[] info = line.Split("; ");
            if (info.Length > 2)
            {
                PremiumUser newUser = new PremiumUser(info[0], info[1], info[2]);
                users.Add(newUser);
            }
        }

        foreach (PremiumUser u in users)
        {
            if (u.Username == Username && u.Password == Password)
            {
                LoggedIn = true;
                Console.WriteLine("premium user");
                Console.ReadKey();
            }
        }
    }

    public override string ToString()
    {
        // This ToString method further overrides the other one, adding in info about discountlevel
        return $"################" +
               $"Här är din info:\n" +
               $"Ditt användarnamn är {Username}\n" +
               $"Ditt lösenord är {Password}\n" +
               $"Du är {DiscountName}-kund och får därför {DiscountLevel * 100}% rabatt på alla priser!\n" +
               $"Gå till Kundvagn för att se kundvagn\n" +
               $"################";
    }
}