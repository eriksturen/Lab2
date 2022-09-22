using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Shop
    {

        string prompt = @"
    ██╗  ██╗██╗   ██╗███╗   ██╗██████╗ ███████╗██████╗  ██████╗ ██████╗ ████████╗       ██╗        ██████╗ ██████╗ 
    ██║  ██║██║   ██║████╗  ██║██╔══██╗██╔════╝██╔══██╗██╔═══██╗██╔══██╗╚══██╔══╝       ██║       ██╔════╝██╔═══██╗
    ███████║██║   ██║██╔██╗ ██║██║  ██║███████╗██████╔╝██║   ██║██████╔╝   ██║       ████████╗    ██║     ██║   ██║
    ██╔══██║██║   ██║██║╚██╗██║██║  ██║╚════██║██╔═══╝ ██║   ██║██╔══██╗   ██║       ██╔═██╔═╝    ██║     ██║   ██║
    ██║  ██║╚██████╔╝██║ ╚████║██████╔╝███████║██║     ╚██████╔╝██║  ██║   ██║       ██████║      ╚██████╗╚██████╔╝
    ╚═╝  ╚═╝ ╚═════╝ ╚═╝  ╚═══╝╚═════╝ ╚══════╝╚═╝      ╚═════╝ ╚═╝  ╚═╝   ╚═╝       ╚═════╝       ╚═════╝ ╚═════╝ 
                                                                                                                   
    Välkommen till Hundsport & Co!
    (Välj alternativ nedan med hjälp av piltangenterna och enter.)
    ";

        public void Start()
        {
            Console.Title = "Hundsport & Co";
            RunMainMenu();

        }

        private void RunMainMenu()
        {
            string[] options = { "Mat", "Leksaker", "Koppel, halsband och selar", "Kassa", "Kundvagn", "Avsluta" };
            Menu mainMenu = new Menu(prompt, options);
            // tutorial makes this be saved as a variable. It is right now not strictly needed
            int selectedIndex = mainMenu.Run();


            // having to do a switch statement for each new menu is irritating - better way should be possible 
            switch (selectedIndex)
            {
                case 0:
                    Mat();
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    Tillbaka();
                    break;
                default:
                    break;
            }
        }

        private void Tillbaka()
        {
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
            Environment.Exit(0);
        }

        private void Mat()
        {
            string[] options = { "Standardt extra", "Royal Canin", "Köttfärs på tunna", "Tillbaka" };
            Menu matMenu = new Menu(prompt, options);
            int selectedIndex = matMenu.Run();
            if (selectedIndex == options.Length-1)
            {
                RunMainMenu();
            }
        }
    }
}
