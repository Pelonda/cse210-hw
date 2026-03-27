using System;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Main St", "Provo", "UT", "USA");
        Customer customer1 = new Customer("John Smith", address1);

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Laptop Stand", 1001, 29.99m, 2));
        order1.AddProduct(new Product("Wireless Mouse", 1002, 19.50m, 1));
        order1.AddProduct(new Product("USB Hub", 1003, 15.00m, 3));

        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total: ${order1.GetTotalCost():0.00}");
        Console.WriteLine();

        Address address2 = new Address("45 King Street", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Emily Brown", address2);

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Notebook", 2001, 4.75m, 5));
        order2.AddProduct(new Product("Pen Pack", 2002, 6.25m, 2));

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total: ${order2.GetTotalCost():0.00}");
    }
}