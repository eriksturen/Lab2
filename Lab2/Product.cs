namespace Lab2;

public class Product
{
    public enum Categories
    {
        Mat,
        Leksaker,
        Koppel
    }
    // Product class. To populate lists for the menu class and so on 
    public string Name { get; set; }
    public Categories Category { get; set; }
    public int Price { get; set; }

    public Product(string name, Categories category, int price)
    {
        Name = name;
        Category = category;
        Price = price;
    }
}