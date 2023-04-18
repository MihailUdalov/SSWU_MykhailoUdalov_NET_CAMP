using System;
using System.Collections.Generic;

namespace Task2
{
    internal class MenuHelper
    {
        private static readonly string menu = "1.Create Supermarket\n" +
            "2.Buy product\n" +
            "3.Exit";
        private static Supermarket Supermarket;
        public static void ShowMenu()
        {
            User user = new User();
            while (true)
            {
                if (Supermarket != null)
                {
                    Console.WriteLine(Supermarket);
                    Console.WriteLine("2.Buy product\n3.Exit");
                }
                else
                {
                    Console.WriteLine(menu);
                }            
                Console.Write("Enter you answer: ");
                switch (Console.ReadLine())
                {
                    case "1":
                        {
                            Supermarket = CreateSupermarket();
                            Console.Clear();
                            break;
                        }
                    case "2":
                        {
                            if (Supermarket == null)
                            {
                                Console.WriteLine("Error, you need to create a supermarket");
                                break;
                            }

                            Console.Write("Enter product name: ");
                            string name = Console.ReadLine();
                            Console.Write("Enter width: ");
                            double width =double.Parse(Console.ReadLine());
                            Console.Write("Enter height: ");
                            double height = double.Parse(Console.ReadLine());
                            Console.Write("Enter length: ");
                            double length = double.Parse(Console.ReadLine());
                            Console.Write("Please select the department you are purchasing from:");
                            string department = Console.ReadLine();

                            Product product = new Product(name, width, height, length);
                            if (Supermarket.FindProduct(product, department))
                            {
                                user.Products.Add(product);
                                Console.WriteLine("Product add to your bucket");
                            }
                                
                            else
                                Console.WriteLine("Product not found");

                            break;
                        }
                    case "3":
                        return;
                    default:
                        break;
                }
            }

        }

        private static Supermarket CreateSupermarket()
        {
            List<Department> departmentList = new List<Department>();
            Department department = new Department("Meat", new List<Department>(), new List<Product>() {
                new Product("Chicken", 10, 10, 10),
                new Product("Beef", 10, 10, 10),
                new Product("Pork", 10, 10, 10),});
            departmentList.Add(department);

            department = new Department("VegetablesAndFruits", new List<Department>()
            {
                new Department("Vegetables", new List<Department>(), new List<Product>() {
             new Product("Potato", 5, 5, 5),
              new Product("Mushroom", 15, 10, 10),

            }),

            }, new List<Product>() { });

            departmentList.Add(department);

            Supermarket supermarket = new Supermarket("Silpo", departmentList);

            department = new Department("Fruits", new List<Department>(), new List<Product>() {
             new Product("Banano", 5, 15, 5),
              new Product("Peach", 15, 5, 10),
            });
            supermarket.AddDepartment(department, "VegetablesAndFruits");

            return supermarket;
        }
    }
}
