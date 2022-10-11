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
        public User? User { get; set; }
        public PremiumUser? PremiumUser { get; set; }

        // Currency name and value gets sent to Menu for calcs
        private string _currencyName;

        public string CurrencyName
        {
            get { return _currencyName; }
            set
            {
                _currencyName = value;
                switch (CurrencyName)
                {
                    case "kr":
                        CurrencyValue = 1;
                        break;
                    case "$":
                        CurrencyValue = 0.12f;
                        break;
                    case "euro":
                        CurrencyValue = 0.10f;
                        break;
                }
            }
        }


        public float CurrencyValue { get; set; }


        CartClass cart = new();

        public Shop(User user)
        {
            CurrencyName = "kr";
            User = user;
        }

        public Shop(PremiumUser user)
        {
            CurrencyName = "kr";
            PremiumUser = user;
        }

        public void Start()
        {
            Console.Title = "Hundsport & Co";
            RunMainMenu();
        }

        private void RunMainMenu()
        {
            List<string> baseOptions = new List<string>()
            {
                "Mat", "Leksaker", "Koppel, halsband och selar", "Kundvagn", "Kassa", "Användarinfo", "Valuta",
                "Logga ut",
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
                    Cashier();
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
                case "Valuta":
                    Valuta();
                    break;
                case "Logga ut":
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

                    Menu newMenu = new Menu(Program.prompt, products, CurrencyName, CurrencyValue);
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

        // cart menu is a bit different to the regular menu
        // since the only real functions in it should be to see the cart
        // remove products and see total price 
        private void Cart()
        {
            string cartPrompt = $"{Program.prompt} \n" +
                                $"--------------------------------------------------------\n" +
                                $" Total kostnad för alla varor i korgen: {cart.TotalPrice * CurrencyValue} {CurrencyName} \n" +
                                $" Ta bort en vara genom att markera den och trycka enter \n" +
                                $"--------------------------------------------------------\n";
            List<Product> cartProducts = cart.GetCart();
            Menu cartMenu = new Menu(cartPrompt, cartProducts, CurrencyName, CurrencyValue);
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

        private void Cashier()
        {
            string cashierPrompt = $"{Program.prompt} \n" +
                                   $"--------------------------------------------------------\n" +
                                   $" Total kostnad för alla varor i korgen: {cart.TotalPrice * CurrencyValue} {CurrencyName} \n" +
                                   $" Välj betala eller gå tillbaka för att handla mer. \n" +
                                   $"--------------------------------------------------------\n";
            List<string> options = new List<string>
            {
                "Betala", "Tillbaka", "Avsluta"
            };
            Menu cashierMenu = new Menu(cashierPrompt, options);
            int selectedIndex = cashierMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    cart.EmptyCart();
                    Console.WriteLine();
                    Console.WriteLine("Tack för ditt köp. Din varukorg är nu tom. \n" +
                                      "Dina varor skickas inom 2-5 arbetsdagar. Tack för att du handlar hos oss! \n" +
                                      "Du kommer nu att loggas ut. Logga in igen för att handla mer.");
                    Console.ReadKey();
                    string[] args = { };
                    Program.Main(args);
                    break;
                case 1:
                    RunMainMenu();
                    break;
                case 2:
                    Exit();
                    break;
            }
        }

        private void Valuta()
        {
            string valutaPrompt = $"{Program.prompt} \n" +
                                  $"--------------------------------------------------------\n" +
                                  $" Här kan du ändra vilken valuta priserna visas i. \n" +
                                  $" Välj en valuta nedan genom att markera och trycka enter. \n" +
                                  $"--------------------------------------------------------\n";
            List<string> options = new List<string>
            {
                "Kronor", "USDollar", "Euro", "Tillbaka"
            };
            Menu valutaMenu = new Menu(valutaPrompt, options);
            int selectedIndex = valutaMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    Console.WriteLine("Valuta är nu kronor.");
                    CurrencyName = "kr";
                    Console.ReadKey();
                    Valuta();
                    break;
                case 1:
                    Console.WriteLine("Valuta är nu USDollar.");
                    CurrencyName = "$";
                    Console.ReadKey();
                    Valuta();
                    break;
                case 2:
                    Console.WriteLine("Valuta är nu Euro.");
                    CurrencyName = "euro";
                    Console.ReadKey();
                    Valuta();
                    break;
                case 3:
                    RunMainMenu();
                    break;
            }
        }
    }
}