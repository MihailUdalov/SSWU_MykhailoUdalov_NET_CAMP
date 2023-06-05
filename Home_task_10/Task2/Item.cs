namespace Task2
{
    internal abstract class Item
    {
        public string Name { get; set; }
        public decimal Price { get; protected set; }
        public decimal ShippingCost { get; protected set; }
        public int Weight { get; protected set; }
        public int Size { get; protected set; }

        public Item()
        {
            
        }
        public Item(string name,decimal price, int weight, int size)
        {
            Name = name;
            Price = price;
            Weight = weight;
            Size = size;
        }
        public abstract void Accept(IVisitor visitor);

        public override string ToString()
        {
            return $"Name:{Name}, Price:{Price},Weight:{Weight},Size:{Size},ShippingCost:{ShippingCost}";
        }
    }
}
