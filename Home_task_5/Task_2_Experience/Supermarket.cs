using System.Collections.Generic;
using System.Linq;

namespace Task2
{
    internal class Supermarket : IBox
    {
        public string Name { get; private set; }
        public List<Box<Department>> Boxes { get; private set; }

        public Supermarket(string name, List<Department> departments)
        {
            Name = name;
            Boxes = departments.Select(dep => new Box<Department>(dep)).ToList();
        }

        public void AddDepartment(Department subDepartment, string departmentName, List<Department> rootDepartments = null)
        {
            var departments = Boxes.Select(b => b.Value).ToList();

            if (rootDepartments == null)
                rootDepartments = departments;

            foreach (Department dep in rootDepartments)
            {
                if (dep.Name == departmentName)
                {
                    dep.AddSubDepartments(subDepartment);
                    return;
                }

                AddDepartment(subDepartment, departmentName, dep.SubDepartments.Select(subDep => subDep.Value).ToList());
            }
        }

        public void AddProduct(Product product, string departmentName, List<Department> rootDepartments = null)
        {
            var departments = Boxes.Select(b => b.Value).ToList();

            if (rootDepartments == null)
                rootDepartments = departments;

            foreach (Department dep in rootDepartments)
            {
                if (dep.Name == departmentName)
                {
                    dep.AddProduct(product);
                    return;
                }

                AddProduct(product, departmentName, dep.SubDepartments.Select(subDep => subDep.Value).ToList());
            }
        }

        public override string ToString()
        {
            return $"Name: {Name} | Box: {GetBoxSizes()} \n";
        }

        public (double width, double height, double length) GetBoxSizes()
        {
            double width = Boxes.Max(size => size.Width);
            double height = Boxes.Max(size => size.Height);
            double length = Boxes.Max(size => size.Lenght);

            return (width, height, length);
        }
    }
}
