using System;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Product product = new Product("Tomato", 5, true, 1, 2);
            Electronics electronics = new Electronics("Phone", 1000,1, 1);
            Clothing clothing = new Clothing("Shoes", 2000, 3, 2);

            ShippingCostVisitor shippingCostVisitor = new ShippingCostVisitor();

            product.Accept(shippingCostVisitor);
            Console.WriteLine(product);

            electronics.Accept(shippingCostVisitor);
            Console.WriteLine(electronics);

            clothing.Accept(shippingCostVisitor);
            Console.WriteLine(clothing);

            Console.ReadKey();
        }
    }
}
