using System;
using System.Collections.Generic;

class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }

    public Product(string name, decimal price)
    {
        Name = name;
        Price = price;
    }
}

class ProductStack
{
    private Stack<Product> stack;

    public ProductStack()
    {
        stack = new Stack<Product>();
    }

    public void Push(Product product)
    {
        stack.Push(product);
    }

    public Product Pop()
    {
        return stack.Pop();
    }

    public void Display()
    {
        if (stack.Count == 0)
        {
            Console.WriteLine("Стек пуст.");
            return;
        }

        Console.WriteLine("Товары в стеке:");
        foreach (var product in stack)
        {
            Console.WriteLine($"Название: {product.Name}, Цена: {product.Price:C}");
        }
    }

    public decimal CalculateAveragePrice()
    {
        if (stack.Count == 0)
        {
            throw new InvalidOperationException("Стек пуст.");
        }

        decimal total = 0;
        int count = 0;

        foreach (var product in stack)
        {
            total += product.Price;
            count++;
        }

        return total / count;
    }
}

class Program
{
    static void Main()
    {
        ProductStack productStack = new ProductStack();

        productStack.Push(new Product("Товар 1", 100.00m));
        productStack.Push(new Product("Товар 2", 150.50m));
        productStack.Push(new Product("Товар 3", 200.00m));
        productStack.Display();

        try
        {
            decimal averagePrice = productStack.CalculateAveragePrice();
            Console.WriteLine($"Средняя цена товаров: {averagePrice:C}");
        }
        catch (InvalidOperationException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
