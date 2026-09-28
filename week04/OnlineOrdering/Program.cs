using System;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Main St", "Anytown", "CA", "USA");
        Customer customer1 = new Customer("John Doe", address1);

        Product product1 = new Product("Widget", 1, 10.99m, 2);
        Product product2 = new Product("Gadget", 2, 5.49m, 3);

        List<Product> products = new List<Product> { product1, product2 };
        Order order1 = new Order(products, customer1);

        Console.WriteLine("Packing Label:");
        Console.WriteLine(order1.PackingLabel());

        Console.WriteLine("\nShipping Label:");
        Console.WriteLine(order1.ShippingLabel());

        Console.WriteLine($"\nTotal Cost of Order: ${order1.TotalCostOfOrder():0.00}");

        Console.WriteLine("__________________________\n");
        Console.WriteLine("Order 2:");

        Address address2 = new Address("456 Elm St", "Othertown", "ON", "Canada");
        Customer customer2 = new Customer("Jane Smith", address2);

        Product product3 = new Product("Electronics", 3, 15.99m, 1);
        Product product4 = new Product("Doohickey", 4, 7.99m, 4);
        Product product5 = new Product("Wearables", 5, 12.49m, 2);
        List<Product> products2 = new List<Product> { product3, product4, product5 };
        Order order2 = new Order(products2, customer2);

        Console.WriteLine("Packing Label:");
        Console.WriteLine(order2.PackingLabel());

        Console.WriteLine("\nShipping Label:");
        Console.WriteLine(order2.ShippingLabel());

        Console.WriteLine($"\nTotal Cost of Order: ${order2.TotalCostOfOrder():0.00}");
    }
}