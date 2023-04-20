using System;
using System.Text;

namespace Task2
{
    internal class Box<T> where T: IBox
    {
        public T Value { get; set; }
        public string Name { get => Value.Name; }

        public double Width { get; set; }
        public double Height { get; set; }
        public double Lenght { get; set; }

        public Box(T value)
        {
            Value = value;

            value.SizeUpdated += Value_SizeUpdated;
            Value_SizeUpdated(value, false);
        }

        private void Value_SizeUpdated(object sender, bool isParentNeedToBeUpdated)
        {
            if (sender is IBox box && box != null)
            {
                (Width, Height, Lenght) = box.GetBoxSizes();
            }
        }

        public string GetProductDescription(int level = 0)
        {
            string indent = new string('\t', level * 2);

            return $"{indent}Name: {Name} | Box: {Value.GetBoxSizes()}";
        }

        public string GetDepartmentDescription(int level = 0)
        {

            if (Value.GetType() is Department)
            {
                Department department = Value;

                string indent = new string('\t', level * 2);
                StringBuilder sb = new StringBuilder();

                sb.AppendLine($"{indent}Department: {Name} | Box: {Value.GetBoxSizes()}");
                sb.AppendLine($"{indent}Products:");

                foreach (var product in department.Products)
                    sb.AppendLine(product.GetProductDescription(level));


                foreach (var subDepartment in department.SubDepartments)
                    sb.AppendLine(subDepartment.GetDepartmentDescription(level + 1));


                return sb.ToString();
            }
            return "";
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
