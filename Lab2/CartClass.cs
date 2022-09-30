using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using System.Linq;

namespace Lab2;

public class CartClass
{
    public List<Product> CartProducts { get; set; }
    private int _totalPrice;

    public int TotalPrice
    {
        get
        {
            int tot = 0;
            foreach (Product product in CartProducts)
            {
                tot += product.Price * product.CartQuantity;
            }
            _totalPrice = tot;
            return _totalPrice;
        }
        set { _totalPrice = value; }
    }


    public CartClass()
    {
        CartProducts = new List<Product>();
        TotalPrice = 0;
        Product tillbaka = new Product("tillbaka", "Tillbaka", "Kundvagn", "0");
        CartProducts.Add(tillbaka);
    }


    public void AddToCart(int selectedIndex, List<Product> options)
    {
        if (options[selectedIndex].Price != null)
        {
            bool productInCart = CartProducts.Select(word => word.ProductId).Contains(options[selectedIndex].ProductId);

            if (productInCart)
            {
                Product cartProduct =
                    (Product)CartProducts.First(product => product.ProductId == options[selectedIndex].ProductId);
                Console.WriteLine($"{cartProduct.Name} lades till i kundvagnen.");
                cartProduct.CartQuantity++;
                Console.ReadKey();
            }
            else if (!productInCart)
            {
                Product cartProduct = options[selectedIndex];
                this.CartProducts.Add(cartProduct);
                Console.WriteLine($"{cartProduct.Name} lades till i kundvagnen.");
                cartProduct.CartQuantity++;
                Console.ReadKey();
            }
        }
    }

    public void RemoveFromCart(int selectedIndex, List<Product> options)
    {
        if (options[selectedIndex].Price != null)
        {
            bool productInCart = CartProducts.Select(word => word.ProductId).Contains(options[selectedIndex].ProductId);

            if (productInCart)
            {
                Product cartProduct =
                    (Product)CartProducts.First(product => product.ProductId == options[selectedIndex].ProductId);
                Console.WriteLine($"{cartProduct.Name} reducerades med 1 i kundvagnen.");
                if (cartProduct.CartQuantity > 1)
                {
                    cartProduct.CartQuantity--;
                }
                else if (cartProduct.CartQuantity == 1)
                {
                    CartProducts.Remove(cartProduct);
                }
                Console.ReadKey();
            }
        }
    }

    public List<Product> GetCart()
    {
        // The LINQ here makes sure that "Tillbaka" is always last.
        // This is important because last alternative in list is always the back button 
        var OrderedCart = CartProducts.OrderBy(s => s.Name == "Tillbaka").ToList();
        return OrderedCart;
    }
}