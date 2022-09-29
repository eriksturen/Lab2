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
            List<Product> products = GetProducts("Mat");
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
            List<Product> products = GetProducts("Leksaker");
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
            List<Product> products = GetProducts("Koppel");
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
            List<Product> cartProducts = cart.GetCart();
            Menu cartMenu = new Menu(prompt, cartProducts);
            int selectedIndex = cartMenu.Run();
            Back(selectedIndex, cartProducts);
        }

        // TODO 3 Fix Register where PayProducts() possible 


        // Shop class gets a readFromFile function to read in data and create a product from info in a textfile
        // this is so that the shop class can populate it's categories with products
        private List<Product> ReadFromFile()
        {
            List<Product> allProducts = new List<Product>();
            // ReadFromFile gets all the data from the file - first as array of strings, one for each line
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\eriks\Documents\Csharp\Lab2\Products.txt.txt");

            // so for each line we split it and create a product from that info
            // then add to productsList
            foreach (string line in lines)
            {
                string[] info = line.Split("; ");
                Product tempProduct = new Product(info[0], info[1], info[2], info[3]);
                allProducts.Add(tempProduct);
            }

            return allProducts;
        }

        // This function is continuation of ReadFromFile() 
        // here we get products from full list matching the provided category
        private List<Product> GetProducts(string category)
        {
            List<Product> products = new List<Product>();

            foreach (Product product in ReadFromFile())
            {
                Product.Categories productCategory = Enum.Parse<Product.Categories>(category);
                if (product.Category == productCategory)
                {
                    products.Add(product);
                }
            }

            return products;
        }

        private List<string> GetNames(List<Product> products)
        {
            List<string> options = new List<string>();
            foreach (Product product in products)
            {
                options.Add(product.Name);
            }

            options.Add("Tillbaka");
            return options;
        }
    }
}