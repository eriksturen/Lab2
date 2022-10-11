namespace Lab2;

public class Product
{
    public enum Categories
    {
        Main,
        Mat,
        Leksaker,
        Koppel,
        Kundvagn,
    }

    // Product class. To populate lists for the menu class and so on 
    public string ProductId { get; }
    public string? Name { get; }
    public Categories Category { get; }
    public float Price { get; set; }
    public float CartQuantity { get; set; }

    public Product(string productId, string name, string category, string price)
    {
        ProductId = productId;
        Name = name;
        Category = Enum.Parse<Categories>(category);
        Price = float.Parse(price);
    }
}