using System;

namespace Task2
{
    internal class ShippingCostVisitor : IVisitor
    {
        private decimal shippingCostBase;

        public ShippingCostVisitor()
        {
            shippingCostBase = 10;
        }
        public ShippingCostVisitor(decimal shippingCostBase)
        {
            this.shippingCostBase = shippingCostBase;
        }
        public decimal VisitProduct(Product product)
        {
            decimal shippingCost = CalculateBaseShippingCost(product);

            if (product.IsPerishable)
            {
                shippingCost += CalculatePerishableShippingCost(product);
            }

            return Math.Round(shippingCost);
        }

        public decimal VisitElectronics(Electronics electronics)
        {
            return CalculateOversizeCharge(electronics);
        }

        public decimal VisitClothing(Clothing clothing)
        {
            return CalculateTaxCharge(clothing);
        }

        private decimal CalculateBaseShippingCost(Product product)
        {
            return shippingCostBase;
        }

        private decimal CalculatePerishableShippingCost(Product product)
        {
            return shippingCostBase/3;
        }

        private decimal CalculateOversizeCharge(Electronics electronics)
        {
            if (electronics.Weight > 50 && electronics.Size > 10)
                return shippingCostBase * (electronics.Price / 10);
            return shippingCostBase;
        }

        private decimal CalculateTaxCharge(Clothing clothing)
        {
            return shippingCostBase + clothing.Tax;
        }
    }
}
