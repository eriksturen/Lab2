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
            List<string> baseOptions = new List<string>() { "Mat", "Leksaker", "Koppel, halsband och selar", "Kassa", "Kundvagn", "Avsluta" };
            Menu mainMenu = new Menu(prompt, baseOptions);
            // tutorial makes this be saved as a variable. It is right now not strictly needed
            int selectedIndex = mainMenu.Run();

            // having to do a switch statement for each new menu is irritating - better way should be possible 

            switch (selectedIndex)
            {
                case 0:
                    Mat();
                    break;
                case 1:
                    Leksaker();
                    break;
                case 2:
                    KoppelOchHalsband();
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    Exit();
                    break;
                default:
                    break;
            }
        }

        private void Back(int selectedIndex, List<string> options)
        {
            if (selectedIndex == options.Count - 1)
            {
                RunMainMenu();
            }
        }

        private void Exit()
        {
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
            Environment.Exit(0);
        }

        private void Mat()
        {
            List<string> options = new List<string>(){ "Standardt extra", "Royal Canin", "Köttfärs på tunna", "Tillbaka" };
            Menu matMenu = new Menu(prompt, options);
            int selectedIndex = matMenu.Run();
            Back(selectedIndex, options);
            
        }

        private void Leksaker()
        {
            List<string> options = new List<string>() { "Kong", "Frisbee", "Herding ball", "Tillbaka" };
            Menu matMenu = new Menu(prompt, options);
            int selectedIndex = matMenu.Run();
            Back(selectedIndex, options);
        }
        private void KoppelOchHalsband()
        {
            List<string> options = new List<string>() { "Läderhalsband", "Spårlina 10 meter", "Nome-sele",
                "Spårsele 20 meter", "IGP-sele", "Helikopterlyftsele", "Tillbaka" };
            Menu matMenu = new Menu(prompt, options);
            int selectedIndex = matMenu.Run();
            Back(selectedIndex, options);
        }
    }
}
