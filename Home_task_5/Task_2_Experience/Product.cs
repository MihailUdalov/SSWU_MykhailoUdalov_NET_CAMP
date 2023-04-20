using System;

namespace Task2
{
    internal class Product : IBox
    {
        public double Width { get; private set; }
        public double Height { get; private set; }
        public double Length { get; private set; }

        public string Name { get; private set; }

        public IBox Parent { get; set; }

        public Product(string name, double width, double height, double length, IBox parent = null)
        {
            Name = name;
            Width = width;
            Height = height;
            Length = length;
            Parent = parent;
        }

        public event EventHandler<bool> SizeUpdated;
        protected void OnSizeUpdated()
        {
            SizeUpdated?.Invoke(this, true);
        }

        public void UpdateSize()
        {
            OnSizeUpdated();
            Parent?.UpdateSize();
        }

        public string GetProductDescription(int level = 0)
        {
            string indent = new string('\t', level * 2);

            return $"{indent}Name: {Name} | Box: {GetBoxSizes()}";
        }

        public (double width, double height, double length) GetBoxSizes()
        {
            return (++Width, ++Height, ++Length);
        }
    }
}