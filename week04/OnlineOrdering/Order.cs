public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(List<Product> products, Customer customer)
    {
        _products = products;
        _customer = customer;
    }

    public decimal TotalCostOfOrder()
    {
        decimal total = 0;
        foreach (Product product in _products)
        {
            total += product.GetTotalCost();
        }

        total += _customer.IsInUSA() ? 5 : 35;
        return total;
    }

    public string PackingLabel()
    {
        string label = "";
        foreach (Product product in _products)
        {
            label += $"{product.GetName()} (ID: {product.GetProductId()})\n";
        }
        return label;
    }

    public string ShippingLabel()
    {
        return $"{_customer.GetName()}\n{_customer.GetAddress().AddressDisplay()}";
    }
}