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
            UpdateBoxSize();
        }

        public void UpdateBoxSize()
        {
            (Width, Height, Lenght) = Value.GetBoxSizes();
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
