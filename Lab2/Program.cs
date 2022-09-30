namespace Lab2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LoginClass login = new LoginClass();
            login.Login();
            Shop shop = new Shop();
            shop.Start();


            // TODO 6 Fix LogIn() - Class and Methods 

            // TODO 7 LogIn() needs UserClass() - should have a ToString() which writes out the cart "på ett snyggt sätt" 
            // this doesn't really fit with the Menu system though 
        }
    }
}