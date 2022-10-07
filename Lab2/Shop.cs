using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public class Shop
    {
        // TODO 14 DiscountLevel implementation - halfway there. Now needs to update prices in shop 
        public User? User { get; set; }
        public PremiumUser? PremiumUser { get; set;  }

        CartClass cart = new CartClass();
        
        public Shop(User user)
        {
            User = user;
        }

        public Shop(PremiumUser user)
        {
            PremiumUser = user;
        }

        public void Start()
        {
            Console.Title = "Hundsport & Co";
            RunMainMenu();
        }

        // TODO 15 SETTINGS tab where currency can be changed 

        private void RunMainMenu()
        {
            List<string> baseOptions = new List<string>()
            {
                "Mat", "Leksaker", "Koppel, halsband och selar", "Kundvagn", "Kassa", "Användarinfo", "Logga ut",
                "Avsluta"
            };
            Menu mainMenu = new Menu(Program.prompt, baseOptions);
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
            // Cleaner code with a switch statement here instead of all if/elif and so on for all the categories. 
            // More scalable also - easier to figure out where to add a category/button/choice this way 
            switch (category)
            {
                case "Kundvagn":
                    Cart();
                    break;
                case "Kassa":
                    break;
                case "Användarinfo":
                    if (PremiumUser != null)
                    {
                        Console.WriteLine(PremiumUser.ToString());
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine(User.ToString());
                        Console.ReadKey();
                    }
                    RunMainMenu();
                    break;
                case "Logga ut":
                    // TODO 11 Now cycles back to Main() - dunno if this is ok but works as intended?
                    Console.WriteLine("Du är utloggad. Tryck valfri tangent för att fortsätta.");
                    Console.ReadKey();
                    string[] args = { };
                    Program.Main(args);
                    break;
                case "Avsluta":
                    Exit();
                    break;
                default:
                    List<Product> products = DataHandler.GetProducts(category);
                    if (PremiumUser != null)
                    {
                        foreach (Product product in products)
                        {
                            product.Price = (int)(product.Price * PremiumUser.DiscountLevel);
                        }
                    }
                    Menu newMenu = new Menu(Program.prompt, products);
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

                    break;
            }
        }

        // TODO 4 Cart should be saved to UserClass() - available on Login
        // cart menu is a bit different to the regular menu since the only real functions in it should be to see the cart
        // remove products and see total price 
        private void Cart()
        {
            string cartPrompt = $"{Program.prompt} \n" +
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