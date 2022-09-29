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

        CartClass cart = new CartClass();
        DataHandler dataHandler = new DataHandler();

        public void Start()
        {
            Console.Title = "Hundsport & Co";
            RunMainMenu();
        }

        private void RunMainMenu()
        {
            List<string> baseOptions = new List<string>()
                { "Mat", "Leksaker", "Koppel, halsband och selar", "Kundvagn", "Kassa", "Avsluta" };
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
                    Cart();
                    break;
                case 5:
                    Exit();
                    break;
                default:
                    break;
            }
        }

        private void Back(int selectedIndex, List<Product> options)
        {
            if (selectedIndex == options.Count - 1)
            {
                RunMainMenu();
            }
        }

        private void Exit()
        {
            Console.WriteLine("Tack och välkommen åter!");
            Console.ReadKey();
            Environment.Exit(0);
        }

        private void Mat()
        {
            List<Product> products = dataHandler.GetProducts("Mat");
            Menu matMenu = new Menu(prompt, products);
            int selectedIndex = matMenu.Run();
            if (selectedIndex < products.Count - 1)
            {
                cart.AddToCart(selectedIndex, products);
                Mat();
            }
            else
            {
                Back(selectedIndex, products);
            }
        }

        private void Leksaker()
        {
            List<Product> products = dataHandler.GetProducts("Leksaker");
            Menu LeksakerMenu = new Menu(prompt, products);
            int selectedIndex = LeksakerMenu.Run();
            if (selectedIndex < products.Count - 1)
            {
                cart.AddToCart(selectedIndex, products);
                Leksaker();
            }
            else
            {
                Back(selectedIndex, products);
            }
        }

        private void KoppelOchHalsband()
        {
            List<Product> products = dataHandler.GetProducts("Koppel");
            Menu KoppelMenu = new Menu(prompt, products);
            int selectedIndex = KoppelMenu.Run();
            if (selectedIndex < products.Count - 1)
            {
                cart.AddToCart(selectedIndex, products);
                KoppelOchHalsband();
            }
            else
            {
                Back(selectedIndex, products);
            }
        }

        // TODO 4 Cart should be saved to UserClass() - available on Login
        private void Cart()
        {
            string cartPrompt = $"{prompt} \n" +
                                $"---------------------------------------------\n" +
                                $" Total kostnad för alla varor i korgen: {cart.TotalPrice} kr \n" +
                                $"---------------------------------------------\n";
            List<Product> cartProducts = cart.GetCart();
            Menu cartMenu = new Menu(cartPrompt, cartProducts);
            int selectedIndex = cartMenu.Run();
            if (cartProducts.Count > 1)
            {
                if (selectedIndex < cartProducts.Count - 1)
                {
                    cart.RemoveFromCart(selectedIndex, cartProducts);
                    Cart();
                }
                else
                {
                    Back(selectedIndex, cartProducts);
                }
            }
            else
            {
                Back(selectedIndex, cartProducts);
            }
        }

        // TODO 3 Fix Register where PayProducts() possible 


    }
}