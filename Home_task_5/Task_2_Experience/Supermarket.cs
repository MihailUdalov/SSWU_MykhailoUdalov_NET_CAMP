using System;
using System.Collections.Generic;
using System.Linq;

namespace Task2
{
    internal class Supermarket : IBox
    {
        public string Name { get; private set; }
        public List<Box<Department>> Boxes { get; private set; }

        public IBox Parent { get => null; }

        public Supermarket(string name, List<Department> departments)
        {
            Name = name;
            departments.ForEach(d => d.Parent = this);
            Boxes = departments.Select(dep => new Box<Department>(dep)).ToList();
        }

        public event EventHandler<bool> SizeUpdated;

        public void AddDepartment(Department subDepartment, string departmentName, List<Department> rootDepartments = null)
        {
            var departments = Boxes.Select(b => b.Value).ToList();

            if (rootDepartments == null)
                rootDepartments = departments;

            foreach (Department dep in rootDepartments)
            {
                if (dep.Name == departmentName)
                {
                    subDepartment.Parent = dep;
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
                    product.Parent = dep;
                    dep.AddProduct(product);
                    return;
                }

                AddProduct(product, departmentName, dep.SubDepartments.Select(subDep => subDep.Value).ToList());
            }
        }

        public override string ToString()
        {
            return $"Name: {Name} | Box: {GetBoxSizes()} \n" +
                  $"{string.Join("\n", Boxes.Select(d => d.GetDepartmentDescription(1)))}";
            //  return $"Name: {Name} | Box: {GetBoxSizes()} \n";
        }

        public (double width, double height, double length) GetBoxSizes()
        {
            double width = Boxes.Max(size => size.Width);
            double height = Boxes.Max(size => size.Height);
            double length = Boxes.Sum(size => size.Lenght);

            return (width, height, length);
        }

        protected void OnSizeUpdated()
        {
            SizeUpdated?.Invoke(this, true);
        }

        public void UpdateSize()
        {
            OnSizeUpdated();
            Parent?.UpdateSize();
        }
    }
}
