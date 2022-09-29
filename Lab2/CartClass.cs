using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

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

    public void AddToCart(Product product)
    {
        Product cartProduct = product;
        cartProduct.CartQuantity++; 
        CartProducts.Add(cartProduct);
    }

    // TODO 2 Need a function to send names of products to Shop() and then on to Menu() - List<Product>
    public List<Product> GetCart()
    {
        return CartProducts;
    }

}