namespace Ambev.DeveloperEvaluation.Domain.Interfaces.Entities
{
    public interface ISaleItem
    {
        Guid ProductId { get; set; }
        int Quantity { get; set; }
        decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal CalculateDiscounts()
        {
            if (Quantity > 20)
                throw new InvalidOperationException("It is not possible to sell more than 20 identical items.");

            if (Quantity < 4)
                return 0m;

            decimal discountPercentage = 0m;

            if (Quantity >= 4 && Quantity < 10)
                discountPercentage = 0.10m;
            else if (Quantity >= 10 && Quantity <= 20)
                discountPercentage = 0.20m;

            var discount = UnitPrice * Quantity * discountPercentage;
            Discount = discount;
            return discount;
        }
    }
}