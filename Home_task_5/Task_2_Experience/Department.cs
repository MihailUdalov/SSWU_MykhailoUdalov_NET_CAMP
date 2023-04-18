using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task2
{
    internal class Department : IBox
    {
        public string Name { get; private set; }
        public List<Box<Department>> SubDepartments { get; private set; }
        public List<Box<Product>> Products { get; private set; }

        public Department(string name, List<Department> subDepartments, List<Product> products)
        {
            Name = name;
            SubDepartments = subDepartments.Select(subDep => new Box<Department>(subDep)).ToList();
            Products = products.Select(p => new Box<Product>(p)).ToList();
        }

        public void AddProduct(Product product)
        {
            Products.Add(new Box<Product>(product));
            SortProductsByHeight();
        }

        public void AddSubDepartments(Department department)
        {
            SubDepartments.Add(new Box<Department>(department));          
        }

        private void SortProductsByHeight()
        {
            Products = Products.OrderBy(p => p.Height).ToList();
        }

        public string ShowDepartment(int level = 0)
        {
            string indent = new string('\t', level * 2);
            StringBuilder sb = new StringBuilder();

            //sb.AppendLine($"{indent}Department: {Name} | Box: {Box}");
            //sb.AppendLine($"{indent}Products:");

            //foreach (var product in Products)
            //    sb.AppendLine(product.ShowProduct(level));

            //foreach (var subDepartment in SubDepartments)
            //    sb.AppendLine(subDepartment.ShowDepartment(level + 1));

            return sb.ToString();
        }

        public (double width, double height, double length) GetBoxSizes()
        {
            double width = 0;
            double height = 0;
            double length = 0;

            if (SubDepartments.Count > 0)
            {
                width = SubDepartments.Max(size => size.Width);
                height = SubDepartments.Max(size => size.Height);
                length = SubDepartments.Max(size => size.Lenght);
            }

            if (Products.Count > 0)
            {
                width = Math.Max(width, Products.Max(size => size.Width));
                height = Math.Max(height, Products.Max(size => size.Height));
                length = Math.Max(length, Products.Max(size => size.Lenght));
            }

            return (width, height, length);
        }
    }
}
