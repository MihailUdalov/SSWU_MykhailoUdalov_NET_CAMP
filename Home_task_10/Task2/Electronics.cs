namespace Task2
{
    internal class Electronics : Item
    {
        public Electronics()
        {

        }
        public Electronics(string name, decimal price, int weight, int size) : base(name, price, weight, size)
        {

        }
        public override void Accept(IVisitor visitor)
        {
            ShippingCost = visitor.VisitElectronics(this);
        }
    }
}
