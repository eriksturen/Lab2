namespace Lab2;

public class DataHandler
{
    // These functions were moved from the Shop class. They're just copy pasted.
    // Don't really know if this counts a "real" class because the functions are all there is. 
    // But a bit more tidy to have them here instead of cluttering the Shop file 

    // GetProducts function to read in data and create a product from info in a textfile
    // this is so that the shop class can populate it's categories with products
    // this functions was combined with an earlier unnecessary one that got all files. 
    // Now, instead of getting all products the method gets the necessary ones from the "database"
    // each time a category is requested
    // Maybe a bit inefficient but it's more scalable i think?
    // Seems weird to store the whole Shop database on client computer

    // methods are static because no need to create an object for each of these i think?
    public static List<Product> GetProducts(string category)
    {
        List<Product> products = new List<Product>();
        string[] lines = File.ReadAllLines($"{Environment.CurrentDirectory}/Products.txt");

        foreach (string line in lines)
        {
            string[] info = line.Split("; ");
            Product product = new Product(info[0], info[1], info[2], info[3]);
            Product.Categories productCategory = Enum.Parse<Product.Categories>(category);
            if (product.Category == productCategory)
            {
                products.Add(product);
            }
        }

        return products;
    }

    public static void WriteNewUser(User user)
    {
        string line = $"{user.Username}; {user.Password}";
        File.AppendAllText($"{Environment.CurrentDirectory}/Users.txt",
            line + Environment.NewLine);
    }
}