namespace Lab2;

public class PremiumUser : User
{
    private string? _discountName;

    public string? DiscountName
    {
        get { return _discountName; }
        set
        {
            _discountName = value;
            switch (DiscountName)
            {
                case "Gold":
                    _discountLevel = 0.85f;
                    break;
                case "Silver":
                    _discountLevel = 0.90f;
                    break;
                case "Bronze":
                    _discountLevel = 0.95f;
                    break;
                default:
                    _discountLevel = 0f;
                    break;
            }
        }
    }

    private float _discountLevel;

    public float DiscountLevel
    {
        get { return _discountLevel; }
        set { _discountLevel = value; }
    }





    public PremiumUser(string username, string password, string discountName) : base(username, password)
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
            else
            {
                PremiumUser newUser = new PremiumUser(info[0], info[1], DiscountName="zero");
                users.Add(newUser);
            }
        }

        foreach (PremiumUser u in users)
        {
            if (u.Username == Username && u.Password == Password)
            {
                LoggedIn = true;
                DiscountName = u.DiscountName;
            }
        }
    }

    public override string ToString()
    {
        // This ToString method further overrides the other one, adding in info about discountlevel
        return $"#############################################################\n" +
               $"Här är din info:\n" +
               $"Ditt användarnamn är {Username}\n" +
               $"Ditt lösenord är {Password}\n" +
               $"Du är {DiscountName}-kund och får därför {Math.Round((1-DiscountLevel) * 100)}% rabatt på alla priser!\n" +
               $"Gå till Kundvagn för att se kundvagn\n" +
               $"#############################################################";
    }
}