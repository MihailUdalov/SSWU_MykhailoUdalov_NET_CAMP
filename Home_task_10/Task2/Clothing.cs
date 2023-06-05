namespace Task2
{
    internal class Clothing : Item
    {
        public decimal Tax { get; private set; }

        public Clothing()
        {

        }
        public Clothing(string name, decimal price, int weight, int size) : base(name, price, weight, size)
        {
            Tax = price / 20;
        }

        public Clothing(string name, decimal price, decimal tax, int weight, int size) : base(name, price, weight, size)
        {
            Tax = tax;
        }

        public override void Accept(IVisitor visitor)
        {
            ShippingCost = visitor.VisitClothing(this);
        }
    }
}
