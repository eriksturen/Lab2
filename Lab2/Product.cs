namespace Lab2;

public class Product
{
    public enum Categories
    {
        Main,
        Mat,
        Leksaker,
        Koppel,
    }
    // Product class. To populate lists for the menu class and so on 
    public string ProductId { get; set; }
    public string Name { get; set; }
    public Categories Category { get; set; }
    public int Price { get; set; }

    public Product(string productId, string name, string category, string price)
    {
        ProductId = productId;
        Name = name;
        Category = Enum.Parse<Categories>(category);
        Price = int.Parse(price);
    }

    
}