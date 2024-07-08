public class Order
{
    public string UserName { get; private set; }
    public string ProductName { get; private set; }
    public int CountProduct { get; private set; }
    public string Address { get; private set; }

    public Order( string userName, string productName, int count, string address )
    {
        UserName = userName;
        ProductName = productName;
        CountProduct = count;
        Address = address;
    }
}
