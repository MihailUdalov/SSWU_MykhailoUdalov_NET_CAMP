using System;

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

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
