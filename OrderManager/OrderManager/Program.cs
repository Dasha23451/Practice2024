class Program
{
    static string ReadUserName()
    {
        Console.Write("Enter your name: ");
        string userName = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(userName))
        {
            userName = Console.ReadLine();
        }

        return userName;
    }

    static string ReadProductName()
    {
        Console.Write("Enter product name: ");
        string productName = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(productName))
        {
            productName = Console.ReadLine();
        }

        return productName;
    }

    static int GetCountProduct()
    {
        Console.Write("Enter product quantity: ");
        string count = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(count))
        {
            count = Console.ReadLine();
        }
        int goods_quantity = Int32.Parse(count);

        return goods_quantity;
    }

    static string GetDeliveryAddress()
    {
        Console.Write("Enter delivery address: ");
        string address = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(address))
        {
            address = Console.ReadLine();
        }

        return address;
    }

    static void OrderConfirmation(string name, string product, int count, string address)
    {
        Console.WriteLine($"Hello, {name}, you ordered {count} {product} to address {address}, is that right? (y/n)");
        string confirmation = Console.ReadLine();
        if (confirmation.ToLower() == "y")
        {
            DateTime todays_date = DateTime.Today;
            DateTime delivery_date = todays_date.AddDays(3);

            Console.WriteLine($"{name}! Your order {product} in quantity {count} decorated! Expect delivery to {address}  {delivery_date:d}");
        }
        else
        {
            Console.WriteLine("Your order is not completed. Please check your input and try again.");
        }
    }
    static void Main()
    {
        Console.WriteLine("Welcome! Please enter order details:");
        string userName = ReadUserName();
        string productName = ReadProductName();
        int countProduct = GetCountProduct();
        string deliveryAddress = GetDeliveryAddress();
        OrderConfirmation(userName, productName, countProduct, deliveryAddress);
    }
}