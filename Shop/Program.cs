using System;
using System.Collections.Generic;

public class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
}

public class Shop
{
    private readonly List<Product> _products;
    private readonly string _sellerName;

    public Shop(string sellerName)
    {
        _products = new List<Product>();
        _sellerName = sellerName;
    }

    public void AddProduct(Product product)
    {
        if (_products.Exists(p => p.Name == product.Name))
        {
            throw new InvalidOperationException($"Product '{product.Name}' already exists in the shop.");
        }

        _products.Add(product);
    }

    public Product SellProduct(string productName, decimal payment)
    {
        var product = _products.Find(p => p.Name == productName);
        if (product == null)
        {
            throw new InvalidOperationException($"Product '{productName}' does not exist in the shop.");
        }

        if (payment < product.Price)
        {
            throw new InvalidOperationException($"Insufficient payment for product '{productName}'.");
        }

        _products.Remove(product);
        return product;
    }

    public void LiquidateShop()
    {
        if (_products.Count > 0)
        {
            throw new InvalidOperationException("Cannot liquidate the shop while there are still products available.");
        }
    }

    public void CheckSellerAvailability()
    {
        if (string.IsNullOrEmpty(_sellerName))
        {
            throw new InvalidOperationException("No seller available. Cannot perform any operation.");
        }
    }
}

class Program
{
    static void Main()
    {
        // Example usage:
        var shop = new Shop("John Doe");

        var banana = new Product { Name = "Banana", Price = 1.5M };
        
        var apple = new Product { Name = "Apple", Price = 2.0M };

        shop.AddProduct(banana);
       
        shop.AddProduct(apple);

        try
        {
            var payment = 2.5M;
            var soldProduct = shop.SellProduct("Banana", payment);
            Console.WriteLine($"Sold {soldProduct.Name} for ${payment}. Change: ${payment - soldProduct.Price}");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(ex.Message);
        }

        try
        {
            shop.LiquidateShop();
            Console.WriteLine("Shop liquidated successfully.");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(ex.Message);
        }

        try
        {
            shop.CheckSellerAvailability();
            Console.WriteLine($"Seller available: {shop.CheckSellerAvailability}");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
