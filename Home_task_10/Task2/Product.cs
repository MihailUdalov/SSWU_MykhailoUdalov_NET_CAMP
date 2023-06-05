namespace Task2
{
    internal class Product : Item
    {
        public bool IsPerishable { get; private set; }

        public Product()
        {

        }

        public Product(string name, decimal price, bool isPerishable, int weight, int size) : base(name, price, weight, size)
        {
            IsPerishable = isPerishable;
        }
        public override void Accept(IVisitor visitor)
        {

            ShippingCost = visitor.VisitProduct(this);

        }
    }
}
