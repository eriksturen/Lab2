using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public class Shop
    {
        public string prompt = @"
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

        public void Start()
        {
            Console.Title = "Hundsport & Co";
            RunMainMenu();
        }

        private void RunMainMenu()
        {
            List<string> baseOptions = new List<string>()
                { "Mat", "Leksaker", "Koppel, halsband och selar", "Kundvagn", "Kassa", "Logga ut", "Avsluta" };
            Menu mainMenu = new Menu(prompt, baseOptions);
            // tutorial makes this be saved as a variable. It is right now not strictly needed
            int selectedIndex = mainMenu.Run();

            // Get the SubCategories with products - or get Cart/Cashier/Exit functions
            CategoryMenu(baseOptions[selectedIndex].Split(",")[0]);
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


        // Refactored
        private void CategoryMenu(string category)
        {
            if (category == "Kundvagn")
            {
                Cart();
            }
            // TODO 11 Now cycles back to Main() - dunno if this is ok but works as intended?
            else if (category == "Logga ut")
            {
                Console.WriteLine("Du är utloggad. Tryck valfri tangent för att fortsätta.");
                Console.ReadKey();
                string[] args = new string[] { };
                Program.Main(args);
            }
            else if (category == "Avsluta")
            {
                Exit();
            }
            // Cashier() goes here! 
            else
            {
                List<Product> products = DataHandler.GetProducts(category);
                Menu newMenu = new Menu(prompt, products);
                int selectedIndex = newMenu.Run();
                if (selectedIndex < products.Count - 1)
                {
                    cart.AddToCart(selectedIndex, products);
                    CategoryMenu(category);
                }
                else
                {
                    Back(selectedIndex, products);
                }
            }
        }

        // TODO 4 Cart should be saved to UserClass() - available on Login
        // cart menu is a bit different to the regular menu since the only real functions in it should be to see the cart
        // remove products and see total price 
        private void Cart()
        {
            string cartPrompt = $"{prompt} \n" +
                                $"--------------------------------------------------------\n" +
                                $" Total kostnad för alla varor i korgen: {cart.TotalPrice} kr \n" +
                                $" Ta bort en vara genom att markera den och trycka enter \n" +
                                $"--------------------------------------------------------\n";
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