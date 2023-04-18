namespace Task2
{
    internal class Box
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public double Length { get; set; }

        public Box()
        {

        }
        public Box(double width, double height, double length)
        {
            Width = width;
            Height = height;
            Length = length;
        }

        public override string ToString()
        {
            return $"Width: {Width}; Height: {Height}; Length: {Length}";
        }
    }
}
