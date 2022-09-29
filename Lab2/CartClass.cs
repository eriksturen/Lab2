﻿using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using System.Linq;

namespace Lab2;

public class CartClass
{
    // TODO 1 Also need to be able to specify an amount of each product
    public List<Product> CartProducts{ get; set; }
    public int TotalPrice { get; set; }

    public CartClass()
    {
        CartProducts = new List<Product>();
        // TODO 5 maybe total price can be set in the prop instead of separate function? 
        // that way it can be updated each time Get is run? 
        TotalPrice = 0;
        Product tillbaka = new Product("tillbaka", "Tillbaka", "Kundvagn", "0");
        CartProducts.Add(tillbaka);
    }

    // TODO 4 Add CartProduct to cart 

    public void AddToCart(int selectedIndex, List<Product> options)
    {
        if (options[selectedIndex].Price != null)
        {
            bool productInCart = CartProducts.Select(word => word.ProductId).Contains(options[selectedIndex].ProductId);

            if (productInCart)
            {
                Product cartProduct = (Product)CartProducts.First(product => product.ProductId == options[selectedIndex].ProductId);
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

    // TODO 2 Need a function to send names of products to Shop() and then on to Menu() - List<Product>
    public List<Product> GetCart()
    {
        return CartProducts;
    }

}