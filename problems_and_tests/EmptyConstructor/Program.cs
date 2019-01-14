using System;
using System.Collections.Generic;

namespace EmptyConstructor
{
    class Product
    {
        public string Name { get; private set; }
        public decimal Price { get; private set; }

        public Product (string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        Product() { }

        public static List<Product> GetSampleProducts()
        {
            return new List<Product>
            {
                new Product {Name = "A", Price = 1.1m },
                new Product {Name = "B", Price = 1.1m },
                new Product {Name = "C", Price = 1.1m },
                new Product {Name = "D", Price = 1.1m },
            };
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            var p = new Product("A", 1m);
            Console.WriteLine("Hello World!");
        }
    }
}
