namespace Lab2
{
    internal class Program
    {
        public bool ProgramOn { get; set; } = true;
        
        // TODO 12 Do you really need the string[] args in Main()? Seems to work both ways
        public static void Main(string[] args)
        {
            LoginClass login = new LoginClass();
            while (login.LoggedIn != true)
            {
                login.Login();
                if (login.LoggedIn == true)
                {
                    Console.WriteLine("Du är inloggad! Tryck valfri tangent för att börja handla.");
                    Console.ReadKey();
                    Shop shop = new Shop();
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


          

            // TODO 7 LogIn() needs UserClass() - should have a ToString() which writes out the cart "på ett snyggt sätt" 
            // this doesn't really fit with the Menu system though 
        }
    }
}