using System.Collections.Generic;
using System.Linq;

namespace Task2
{// супермаркет-це мав би бути просто департамент 0 рівня.
    internal class Supermarket
    {
        public string Name { get; private set; }
        public List<Department> Departments { get; private set; }
        public Box Box { get; private set; }

        public Supermarket(string name, List<Department> departments)
        {
            Name = name;
            Departments = departments;
            CreateBox();
        }
// Не продумано до кінця систему обходу по ієрархічній структурі.
        public void AddDepartment(Department subDepartment, string departmentName, List<Department> rootDepartments = null)
        {
            if (departmentName == "")
            {
                subDepartment.CreateBox();
                Departments.Add(subDepartment);
                CreateBox();
                return;
            }
            if (rootDepartments == null)
                rootDepartments = Departments;

            foreach (Department dep in rootDepartments)
            {
                if (dep.Name == departmentName)
                {
                    dep.AddSubDepartments(subDepartment);
                    CreateBox();
                    return;
                }

                AddDepartment(subDepartment, departmentName, dep.SubDepartments);
            }
        }

        public void AddProduct(Product product, string departmentName, List<Department> rootDepartments = null)
        {
            if (rootDepartments == null)
                rootDepartments = Departments;

            foreach (Department dep in rootDepartments)
            {
                if (dep.Name == departmentName)
                {
                    dep.AddProduct(product);

                    CreateBox();
                    return;
                }

                AddProduct(product, departmentName, dep.SubDepartments);
            }
        }

        public bool FindProduct(Product product, string departmentName, List<Department> rootDepartments = null)
        {
            if (rootDepartments == null)
                rootDepartments = Departments;

            foreach (Department dep in rootDepartments)
            {
                if (dep.Name == departmentName)
                {
                    return dep.Products.Any(p => p.Name == product.Name && p.Box.Length == product.Box.Length && 
                    p.Box.Width == product.Box.Width && p.Box.Height == product.Box.Height);
                }

                if (FindProduct(product, departmentName, dep.SubDepartments))
                    return true;
            }

            return false;
        }


        public void CreateBox()
        {
            Box = new Box();
            if (Departments.Count > 0)
            {
                UpdateBoxSize();
                Box = new Box(Departments.Max(d => d.Box.Width), Departments.Max(d => d.Box.Height), Departments.Sum(d => d.Box.Length));
            }

        }


        public bool UpdateBoxSize(List<Department> rootDepartments = null)
        {
            if (rootDepartments == null)
                rootDepartments = Departments;

            foreach (Department dep in rootDepartments)
            {
                dep.CreateBox();

                UpdateBoxSize(dep.SubDepartments);
            }

            return false;
        }
        public override string ToString()
        {
            return $"Name: {Name} | Box: {Box} \n" +
                   $"{string.Join("\n", Departments.Select(d => d.GetDepartmentDescription(1)))}";
        }
    }
}
