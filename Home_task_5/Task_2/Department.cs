using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task2
{
    internal class Department
    {
        public string Name { get; private set; }
        public Box Box { get; private set; }
        public List<Department> SubDepartments { get; private set; }
        public List<Product> Products { get; private set; }

        public Department(string name, List<Department> subDepartments, List<Product> products)
        {
            Name = name;
            SubDepartments = subDepartments;
            Products = products;
            CreateBox();
        }
        public void AddProduct(Product product)
        {
            Products.Add(product);
            SortProductsByHeight();
            CreateBox();
        }
        public void AddSubDepartments(Department department)
        {
            SubDepartments.Add(department);          
            CreateBox();
        }


        public void CreateBox()
        {
            if(SubDepartments.Count > 0 && Products.Count > 0)
            {
                Box = new Box(Math.Max(Products.Max(p => p.Box.Width), SubDepartments.Max(d => d.Box.Width)),
                Math.Max(Products.Max(p => p.Box.Height), SubDepartments.Max(d => d.Box.Height)), Products.Sum(p => p.Box.Length) + SubDepartments.Sum(d => d.Box.Length));
                return;
            }
            if (SubDepartments.Count > 0)
            {
                Box = new Box(SubDepartments.Max(d => d.Box.Width),
                SubDepartments.Max(d => d.Box.Height), SubDepartments.Sum(d => d.Box.Length));
                return;
            }
            if (Products.Count > 0)
            {
                Box = new Box(Products.Max(p => p.Box.Width),
                Products.Max(p => p.Box.Height), Products.Sum(p => p.Box.Length));
                return;
            }
            Box = new Box();

        }

        private void SortProductsByHeight()
        {
            Products = Products.OrderBy(p => p.Height).ToList();
        }

        public string GetDepartmentDescription(int level = 0)
        {
            string indent = new string('\t', level * 2);
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{indent}Department: {Name} | Box: {Box}");
            sb.AppendLine($"{indent}Products:");

            foreach (var product in Products)
                sb.AppendLine(product.GetProductDescription(level));
            

            foreach (var subDepartment in SubDepartments)
                sb.AppendLine(subDepartment.GetDepartmentDescription(level + 1));
            

            return sb.ToString();
        }
    }
}
