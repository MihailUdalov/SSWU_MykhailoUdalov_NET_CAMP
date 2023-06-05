namespace Task2
{
    internal interface IVisitor
    {
        decimal VisitProduct(Product product);
        decimal VisitElectronics(Electronics electronics);
        decimal VisitClothing(Clothing clothing);
    }
}
