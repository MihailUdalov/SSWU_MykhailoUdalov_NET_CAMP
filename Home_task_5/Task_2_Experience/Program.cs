using System;
using System.Collections.Generic;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Department department = new Department("Meat", new List<Department>(), new List<Product>() { new Product("Chicken", 10, 10, 10) });

            Supermarket supermarket = new Supermarket("Silpo", new List<Department>() { department });

            supermarket.AddDepartment(new Department("Beaf", new List<Department>(), new List<Product>() { new Product("Cow",10,10, 10) }),"Meat");
            supermarket.AddProduct(new Product("JapanCow", 20, 10, 10), "Beaf");

            Box<Supermarket> box = new Box<Supermarket>(supermarket);
            Console.WriteLine(box);
        }
    }
}
