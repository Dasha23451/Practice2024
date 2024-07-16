class Program
{
    static int GetCountProduct()
    {
        Console.Write( "Enter product quantity: " );
        string count = Console.ReadLine();
        int goods_quantity;
        while ( string.IsNullOrWhiteSpace( count ) )
        {
            count = Console.ReadLine();
        }
        while ( !( int.TryParse( count, out goods_quantity ) && goods_quantity > 0 ) )
        {
            Console.WriteLine( "Quantity must be a number and greater than 0. Enter a value" );
            count = Console.ReadLine();
        }
        return goods_quantity;
    }

    static string GetStringData( string message )
    {
        Console.Write( message );
        string value = Console.ReadLine();
        while ( string.IsNullOrWhiteSpace( value ) )
        {
            Console.WriteLine( "String cannot be empty. Enter a value:" );
            value = Console.ReadLine();
        }

        return value;
    }

    static void OrderConfirmation( Order order )
    {
        Console.WriteLine( $"Hello, {order.UserName}, you ordered {order.CountProduct} will be delivered {order.ProductName} to {order.Address}, is that right? (y/n)" );
        string confirmation = Console.ReadLine();
        if ( confirmation.ToLower() == "y" )
        {
            DateTime todays_date = DateTime.Today;
            DateTime delivery_date = todays_date.AddDays( 3 );

            Console.WriteLine( $"{order.UserName}! Your order {order.ProductName} in quantity {order.CountProduct} decorated! Expect delivery to {order.Address}  {delivery_date:d}" );
        }
        else
        {
            Console.WriteLine( "Your order is not completed. Please check your input and try again." );
        }

    }
    static Order CreateOrder()
    {
        string name = GetStringData( "Enter your name: " );
        string product = GetStringData( "Enter product name: " );
        int count = GetCountProduct();
        string address = GetStringData( "Enter delivery address: " );
        Order userOrder = new Order( name, product, count, address );
        return userOrder;
    }

    static void Main()
    {
        Console.WriteLine( "Welcome! Please enter order details:" );
        Order userOrder = CreateOrder();
        OrderConfirmation( userOrder );
    }
}