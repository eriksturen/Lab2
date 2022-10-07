﻿using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;

namespace Lab2
{
    internal class Program
    {
        public static string prompt = @"
    ██╗  ██╗██╗   ██╗███╗   ██╗██████╗ ███████╗██████╗  ██████╗ ██████╗ ████████╗       ██╗        ██████╗ ██████╗ 
    ██║  ██║██║   ██║████╗  ██║██╔══██╗██╔════╝██╔══██╗██╔═══██╗██╔══██╗╚══██╔══╝       ██║       ██╔════╝██╔═══██╗
    ███████║██║   ██║██╔██╗ ██║██║  ██║███████╗██████╔╝██║   ██║██████╔╝   ██║       ████████╗    ██║     ██║   ██║
    ██╔══██║██║   ██║██║╚██╗██║██║  ██║╚════██║██╔═══╝ ██║   ██║██╔══██╗   ██║       ██╔═██╔═╝    ██║     ██║   ██║
    ██║  ██║╚██████╔╝██║ ╚████║██████╔╝███████║██║     ╚██████╔╝██║  ██║   ██║       ██████║      ╚██████╗╚██████╔╝
    ╚═╝  ╚═╝ ╚═════╝ ╚═╝  ╚═══╝╚═════╝ ╚══════╝╚═╝      ╚═════╝ ╚═╝  ╚═╝   ╚═╝       ╚═════╝       ╚═════╝ ╚═════╝ 
                                                                                                                   
    Välkommen till Hundsport & Co!
    (Välj alternativ nedan med hjälp av piltangenterna och enter.)
    ";


        // TODO 12 Do you really need the string[] args in Main()? Seems to work both ways
        public static void Main(string[] args)
        {
            bool LoggedIn = false;
            // LoggedIn is set to false when a new LoginClass is created
            // so when "Logga ut" is chosen in Shop() a new LoginClass is created,
            // where the user isn't logged in.

            // Ändringar i login bode bli typ: fråga om vill logga in - isåfall skriv in uesr/pass
            // 
            List<string> options = new List<string>() { "Logga in", "Registrera ny användare" };
            Menu loginMenu = new Menu(prompt, options);
            int selectedIndex = loginMenu.Run();



            while (LoggedIn != true)
            {
                if (selectedIndex == 0)
                {
                    PremiumUser user = new PremiumUser();
                    user.Login();
                    if (user.LoggedIn)
                    {
                        LoggedIn = true;
                        Console.WriteLine("Du är inloggad! Tryck valfri tangent för att börja handla.");
                        Console.WriteLine($"username should be here {user.Username}");
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
                        string[] newArgs = new string[] {};
                        Main(newArgs);
                    }
                }
                else if (selectedIndex == 1)
                {
                    User user = new User();
                    user.RegisterUser();
                }
            }
        }
    }
}