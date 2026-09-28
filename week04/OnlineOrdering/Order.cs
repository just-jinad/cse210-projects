public class Order
{
    private List<Product> products;
    private Customer customer;

    public Order(List<Product> products, Customer customer)
    {
        this.products = products;
        this.customer = customer;
    }

    public double TotalCostOfOrder()
    {
        double total = 0;
        foreach (Product product in products)
        {
            total += product.GetTotalCost();
        }

        total += customer.IsInUSA() ? 5 : 35;
        return total;
    }

    public string PackingLabel()
    {
        string label = "";
        foreach (Product product in products)
        {
            label += $"{product.GetName()} (ID: {product.GetProductId()})\n";
        }
        return label;
    }

    public string ShippingLabel()
    {
        return $"{customer.GetName()}\n{customer.GetAddress().AddressDisplay()}";
    }
}