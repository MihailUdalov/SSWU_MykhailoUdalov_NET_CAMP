namespace Task2
{
    internal class Product : IBox
    {
        public double Width { get; private set; }
        public double Height { get; private set; }
        public double Length { get; private set; }

        public string Name { get; private set; }

        public Product(string name, double width, double height, double length)
        {
            Name = name;
            Width = width;
            Height = height;
            Length = length;
        }

        public (double width, double height, double length) GetBoxSizes()
        {
            return (++Width, ++Height, ++Length);
        }
    }
}
