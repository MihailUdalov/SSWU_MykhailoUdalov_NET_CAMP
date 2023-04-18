using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    internal class Product
    {
        public string Name { get; private set; }
        public double Width { get; private set; }
        public double Height { get; private set; }
        public double Length { get; private set; }
        public Box Box { get; private set; }

        public Product(string name, double width, double height, double length)
        {
            Name = name;
            Width = width;
            Height = height;
            Length = length;
            CreateBox();
        }
        
        public void CreateBox()
        {
            Box = new Box(Width, Height, Length);
        }

        public string GetProductDescription(int level = 0)
        {
            string indent = new string('\t', level * 2);

            return $"{indent}Name: {Name} | Box: {Box}";
        }

        public override string ToString()
        {
            return $"Name: {Name} | Box: {Box}";
        }
    }
}
