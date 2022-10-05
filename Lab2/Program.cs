namespace Lab2
{
    internal class Program
    {
        // TODO 12 Do you really need the string[] args in Main()? Seems to work both ways
        public static void Main(string[] args)
        {
            // LoggedIn is set to false when a new LoginClass is created
            // so when "Logga ut" is chosen in Shop() a new LoginClass is created,
            // where the user isn't logged in.
            User user = new User();

            while (user.LoggedIn != true)
            {
                user.Login();
                if (user.LoggedIn == true)
                {
                    Console.WriteLine("Du är inloggad! Tryck valfri tangent för att börja handla.");
                    Console.ReadKey();
                    Shop shop = new Shop(user);
                    shop.Start();
                }
                else
                {
                    Console.WriteLine("Fel lösenord eller användaren ej registrerad. \n" +
                                      "Försök igen eller registrera ny användare. \n" +
                                      "(Tryck valfri tangent för att komma vidare.)");
                    Console.ReadKey();
                }
            }
        }
    }
}