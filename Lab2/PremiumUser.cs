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

    public PremiumUser(string userName, string password, string discountName) : base(userName, password)
    {
        DiscountName = discountName;
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